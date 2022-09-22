using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Internal;
using System;
using System.Collections.Generic;

namespace ZTools
{

	public class SceneLoadTool : MonoBehaviour
	{
		/// <summary>
		/// 实例化
		/// </summary>
		private static SceneLoadTool instance = null;
		private static object oLock = new object();
		public static SceneLoadTool Instance
		{
			get
			{
				if (null == instance)
				{
					lock (oLock)
					{
						GameObject obj = new GameObject();
						obj.name = "SceneLoadTool(Singleton)";
						SceneLoadTool sceneLoadTool = obj.AddComponent<SceneLoadTool>();
						SceneLoadTool.instance = sceneLoadTool;
						DontDestroyOnLoad(obj);
					}
				}
				return instance;
			}
		}
		/// <summary>
		/// 获取加载进度，加载成功后需返回true，否则为false；
		/// </summary>
		public event Func<float, bool> LoadEvent;
		private string loadingPageName = "Loading";
		/// <summary>
		/// 设置默认loading页面名称
		/// </summary>
		public string DefaultLoadingPageName
		{
			set { loadingPageName = value; }
		}
		private bool allowSceneActivation = false;
		public bool AllowSceneActivation
        {
            set { allowSceneActivation = value; }
        }
		//------------------------------------

		private float targetValue;

		private AsyncOperation sceneAsync;

		private Action successCallBack;

		GameObject loadingObjCanvas;

		GameObject loadObj;

		bool isLoading = false;

		LoadType loadType;

		enum LoadType { Prefab, Scene}

		struct OtherSceneLoad
		{
			public string sceneName;
			public GameObject obj;
			public string loadingSceneName;
			public LoadSceneMode loadSceneMode;
			public Action successCallBack;
			public LoadType loadType;
		}
		List<OtherSceneLoad> sceneLoadList = new List<OtherSceneLoad>();
		/// <summary>
		/// 场景加载，loading页面路径和名称"Resources/Loading"
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		public void SceneLoadWithPrefab(string sceneName)
		{
			if (ExistenceLoadingObj(loadingPageName, out loadObj))
			{
				Load(sceneName, loadObj, LoadSceneMode.Single, null);
			}
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		public void SceneLoadWithPrefab(string sceneName, string loadObjPath)
		{
			if (ExistenceLoadingObj(loadObjPath, out loadObj))
			{
				Load(sceneName, loadObj, LoadSceneMode.Single, null);
			}
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		public void SceneLoadWithPrefab(string sceneName, GameObject loadObj)
		{
			Load(sceneName, loadObj, LoadSceneMode.Single, null);
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		public void SceneLoadWithPrefab(string sceneName, string loadObjPath, LoadSceneMode mode)
		{
			if (ExistenceLoadingObj(loadObjPath, out loadObj))
			{
				Load(sceneName, loadObj, mode, null);
			}
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		public void SceneLoadWithPrefab(string sceneName, GameObject loadObj, LoadSceneMode mode)
		{
			Load(sceneName, loadObj, mode, null);
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		/// <param name="successCallBack">加载完回调</param>
		public void SceneLoadWithPrefab(string sceneName, string loadObjPath, LoadSceneMode mode, Action successCallBack)
		{
			if (ExistenceLoadingObj(loadObjPath, out loadObj))
			{
				Load(sceneName, loadObj, mode, successCallBack);
			}
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		/// <param name="successCallBack">加载完回调</param>
		public void SceneLoadWithPrefab(string sceneName, GameObject loadObj, LoadSceneMode mode, Action successCallBack)
		{
			Load(sceneName, loadObj, mode, successCallBack);
		}
		/// <summary>
		/// 场景加载，loading页面路径和名称"Resources/Loading"
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		public void SceneLoadWithScene(string sceneName)
		{
			Load(sceneName, loadingPageName, LoadSceneMode.Single, null);
		}
		/// <summary>
		/// 场景加载，loading页面路径和名称"Resources/Loading"
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadSceneName">loading场景名称</param>
		public void SceneLoadWithScene(string sceneName, string loadSceneName)
		{
			Load(sceneName, loadSceneName, LoadSceneMode.Single, null);
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		public void SceneLoadWithScene(string sceneName, string loadSceneName, LoadSceneMode mode)
		{
			Load(sceneName, loadSceneName, mode, null);
		}
		/// <summary>
		/// 场景加载
		/// </summary>
		/// <param name="sceneName">加载场景名称</param>
		/// <param name="loadObjPath">loading页面路径</param>
		/// <param name="mode">加载模式</param>
		/// <param name="successCallBack">加载完回调</param>
		public void SceneLoadWithScene(string sceneName, string loadSceneName, LoadSceneMode mode, Action successCallBack)
		{
			Load(sceneName, loadSceneName, mode, successCallBack);
		}
		/// <summary>
		/// 判断路径是否含有对象
		/// </summary>
		/// <param name="loadObjPath"></param>
		/// <returns></returns>
		bool ExistenceLoadingObj(string loadObjPath, out GameObject obj)
		{
			obj = Resources.Load<GameObject>(loadObjPath);
			if (null == obj)
			{
				Debug.LogError("there is no Loading Prefab in Resources, 大佬加个loading页吧😀");
				return false;
			}
			return true;
		}
		/// <summary>
		/// 卸载场景
		/// </summary>
		public void UnLoadScene(string sceneName)
		{
			if (SceneManager.GetSceneByName(sceneName).IsValid())
			{
				SceneManager.UnloadSceneAsync(sceneName);
			}
		}
		void Load(string sceneName, GameObject loadObj, [DefaultValue("LoadSceneMode.Single")]LoadSceneMode loadSceneMode, Action successCallBack)
		{
			if (!isLoading && !SceneManager.GetSceneByName(sceneName).IsValid())
			{
				isLoading = true;
				loadType = LoadType.Prefab;
				this.successCallBack = successCallBack;
				GameObject prefab = (loadingObjCanvas = GetCanvas().gameObject).transform.AddChildWithPrefab(loadObj);
				prefab.GetComponent<RectTransform>().sizeDelta = prefab.transform.parent.GetComponent<RectTransform>().sizeDelta;
				DontDestroyOnLoad(loadingObjCanvas);
				StartCoroutine(AsyncLoading(sceneName, loadSceneMode));
			}
			else
			{
				sceneLoadList.Add(new OtherSceneLoad { sceneName = sceneName, obj = loadObj, loadSceneMode = loadSceneMode, successCallBack = successCallBack, loadType = LoadType.Prefab });
			}
		}
		void Load(string sceneName, string loadSceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode loadSceneMode, Action successCallBack)
		{
            if (!isLoading && !SceneManager.GetSceneByName(sceneName).IsValid())
            {
				isLoading = true;
				this.loadType = LoadType.Scene;
				this.loadingPageName = loadSceneName;
				this.successCallBack = successCallBack;
				SceneManager.LoadSceneAsync(loadSceneName, loadSceneMode);
				StartCoroutine(AsyncLoading(sceneName, loadSceneMode));
			}
            else
            {
				sceneLoadList.Add(new OtherSceneLoad { sceneName = sceneName, loadingSceneName = loadSceneName, loadSceneMode = loadSceneMode, successCallBack = successCallBack, loadType = LoadType.Scene });
			}
		}
		IEnumerator AsyncLoading(string sceneName, LoadSceneMode loadSceneMode)
		{
			sceneAsync = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
			SceneManager.sceneLoaded += OnSceneLoaded;
			//阻止当加载完成自动切换
			sceneAsync.allowSceneActivation = allowSceneActivation;
			yield return sceneAsync;
		}

		void Update()
		{
			if (null != sceneAsync)
			{
				targetValue = targetValue >= 0.9f ? 1 : sceneAsync.progress;
			}
			if (isLoading && null != LoadEvent)
			{
                if (LoadEvent.Invoke(targetValue))
                {
					StartCoroutine(LoadSuccess());
				}
			}
		}
		/// <summary>
		/// 在模块外新建一个canvas
		/// </summary>
		/// <returns></returns>
		Transform GetCanvas()
		{
			GameObject canvasBoxObj = new GameObject();
			Canvas canvasBox = canvasBoxObj.AddComponent<Canvas>();
			canvasBoxObj.AddComponent<GraphicRaycaster>();
			canvasBox.renderMode = RenderMode.ScreenSpaceOverlay;
			canvasBoxObj.name = "LOADINGBOX";
			canvasBox.sortingOrder = 15;
			return canvasBox.transform;
		}
		WaitForSeconds second = new WaitForSeconds(0.1f);
		/// <summary>
		/// ui加载显示结束时，执行该方法
		/// </summary>
		IEnumerator LoadSuccess()
		{
			Debug.Log("加载结束");
			isLoading = false;
			sceneAsync.allowSceneActivation = true;
			sceneAsync = null;
			yield return (loadType == LoadType.Prefab) ? second : null;
			if (null != successCallBack)
			{
				successCallBack();
				successCallBack = null;
			}
			if (sceneLoadList.Count > 0)
			{
				OtherSceneLoad obj = sceneLoadList[sceneLoadList.Count - 1];
                switch (obj.loadType)
                {
                    case LoadType.Prefab:
						SceneLoadWithPrefab(obj.sceneName, obj.obj, obj.loadSceneMode, obj.successCallBack);
						break;
                    case LoadType.Scene:
						SceneLoadWithScene(obj.sceneName, obj.loadingSceneName, obj.loadSceneMode, obj.successCallBack);
						break;
                }
				sceneLoadList.Remove(obj);
			}
            switch (loadType)
            {
                case LoadType.Prefab:
                    Destroy(loadingObjCanvas);
                    loadingObjCanvas = null;
                    break;
                case LoadType.Scene:
					UnLoadScene(loadingPageName);
                    break;
            }
		}
		/// <summary>
		/// 加载完成后设为启动项
		/// </summary>
		/// <param name="a"></param>
		/// <param name="mode"></param>
		void OnSceneLoaded(Scene a, LoadSceneMode mode)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(a.name));
		}
	}
	public static class ExtendUI
	{
		public static GameObject AddChildWithPrefab(this Transform parent, GameObject prefab)
		{
			if (parent == null || prefab == null)
			{
				throw (new NullReferenceException("parent or prefab is null"));
			}

			GameObject obj = GameObject.Instantiate(prefab) as GameObject;
			obj.transform.SetParent(parent);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
			obj.transform.localRotation = Quaternion.identity;
			obj.name = prefab.name;
			obj.SetActive(true);
			return obj;
		}
	}
}