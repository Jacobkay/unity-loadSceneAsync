using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZTools;

public class Loading : MonoBehaviour
{
    public Image slider;
    public Text txt;

    private void Start()
    {
        SceneLoadTool.Instance.LoadEvent += LoadEvent;
    }
    bool LoadEvent(float num)
    {
        bool isComplete = false;
        slider.fillAmount = Mathf.Lerp(slider.fillAmount, num, Time.deltaTime);
        Debug.Log("加载进度：" + slider.fillAmount);
        txt.text = $"{(slider.fillAmount >= 0.99f ? 100 : (slider.fillAmount * 100f)).ToString("0")}%";
        if (slider.fillAmount >= 0.99f)
        {
            isComplete = true;
        }
        return isComplete;
    }
    private void OnDestroy()
    {
        SceneLoadTool.Instance.LoadEvent -= LoadEvent;
    }
}
