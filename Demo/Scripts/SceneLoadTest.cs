using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZTools;

public class SceneLoadTest : MonoBehaviour
{
    public bool prefabSingle = false;
    public bool prefabAdditive = false;
    public GameObject loading;
    public bool sceneSingle = false;
    public bool sceneAdditive = false;
    private Button btn;

    void Start()
    {
        //设置默认loading页名称
        SceneLoadTool.Instance.DefaultLoadingPageName = "Loading";
        //场景加载完之后是否立即初始化, 如果为false则等待loading消失后初始化
        SceneLoadTool.Instance.AllowSceneActivation = true;
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            if (prefabSingle)
            {
                SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("prefabSingle加载回调"); });
            }
            else if (prefabAdditive)
            {
                SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Additive, () => { Debug.LogError("prefabAdditive加载回调"); });
            }
            else if (sceneSingle)
            {
                SceneLoadTool.Instance.SceneLoadWithScene("Main", "Loading", UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("sceneSingle加载回调"); });
            }
            else if (sceneAdditive)
            {
                SceneLoadTool.Instance.SceneLoadWithScene("Main", "Loading", UnityEngine.SceneManagement.LoadSceneMode.Additive, () => { Debug.LogError("sceneAdditive加载回调"); });
            }
        });
    }
}
