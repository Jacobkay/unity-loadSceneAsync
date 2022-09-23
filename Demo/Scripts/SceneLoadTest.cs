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
    public bool twiceClick = false;
    private Button btn;

    void Start()
    {
        //����Ĭ��loadingҳ����
        SceneLoadTool.Instance.DefaultLoadingPageName = "Loading";
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            if (prefabSingle)
            {
                SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("prefabSingle���ػص�"); });
            }
            else if (prefabAdditive)
            {
                SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Additive, () => { Debug.LogError("prefabAdditive���ػص�"); });
            }
            else if (sceneSingle)
            {
                SceneLoadTool.Instance.SceneLoadWithScene("Main", "Loading", UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("sceneSingle���ػص�"); });
            }
            else if (sceneAdditive)
            {
                SceneLoadTool.Instance.SceneLoadWithScene("Main", "Loading", UnityEngine.SceneManagement.LoadSceneMode.Additive, () => { Debug.LogError("sceneAdditive���ػص�"); });
            }
            else if (twiceClick)
            {
                SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("prefabSingle���ػص�"); });
                SceneLoadTool.Instance.SceneLoadWithScene("Start", "Loading", UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("sceneSingle���ػص�"); });
            }
        });
    }
}
