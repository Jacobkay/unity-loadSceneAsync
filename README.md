# Unity可自定义loading页的异步加载工具

#### 介绍
可自定义loading页，prefab和scene都可以，获取当前加载进度，场景异步加载


#### 安装教程

1.  下载代码，引入到工程中，核心脚本为SceneLoadTool
2.  单例类，直接调用接口，传入对应参数即可实现场景异步加载

#### 使用说明
1.  SceneLoadTool为单例类
2.  引入ZTools命名空间
3.  使用预制体或者scene制作自己想要的loading页，通过LoadEvent（下方有介绍）监听加载进度
4.  使用SceneLoadWithPrefab或者SceneLoadWithScene传入跳转到的场景名称和loading页，即可完成场景的异步跳转

内含demo，可查看demo中SceneLoadTest.cs脚本
#### API说明：

1.LoadEvent（广播事件）：获取加载进度，该方法一帧调用一次，加载未完成返回false，加载完成后返回true，即可停止方法的调用

```
/// <summary>
/// 获取加载进度，加载成功后需返回true，否则为false；
/// </summary>
public event Func<float, bool> LoadEvent;
```
2.DefaultLoadingPageName（属性）：如果场景中的loading页数量较少，不需要每次都有变化，可以直接设置默认loading页名称，后期调用可不穿参数

```
/// <summary>
/// 设置默认loading页面名称
/// </summary>
public string DefaultLoadingPageName
{
    set {}
}
```



 **loading页面为预制体格式** 
1. 场景加载，只传加载场景名称，loading页默认路径（Resources/Loading），默认single，无回调
```
/// <summary>
/// 场景加载，loading页面路径和名称"Resources/Loading"
/// </summary>
/// <param name="sceneName">加载场景名称</param>
public void SceneLoadWithPrefab(string sceneName){}
```

2.  场景加载，传加载场景名称，loading页面路径，默认single，无回调
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面路径</param>
public void SceneLoadWithPrefab(string sceneName, string loadObjPath){}
```

3.  场景加载，传加载场景名称，loading页面对象，默认single，无回调
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面对象</param>
public void SceneLoadWithPrefab(string sceneName, GameObject loadObj){}
```

4. 场景加载，传加载场景名称，loading页面路径，加载模式，无回调
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面路径</param>
/// <param name="mode">加载模式</param>
public void SceneLoadWithPrefab(string sceneName, string loadObjPath, LoadSceneMode mode){}
```

5. 场景加载，传加载场景名称，loading页面对象，加载模式，无回调
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面对象</param>
/// <param name="mode">加载模式</param>
public void SceneLoadWithPrefab(string sceneName, GameObject loadObj, LoadSceneMode mode){}
```

6. 场景加载，传加载场景名称，loading页面路径，加载模式，回调函数
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面路径</param>
/// <param name="mode">加载模式</param>
/// <param name="successCallBack">加载完回调</param>
public void SceneLoadWithPrefab(string sceneName, string loadObjPath, LoadSceneMode mode, Action successCallBack){}
```

7.场景加载，传加载场景名称，loading页面对象，加载模式，回调函数
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面对象</param>
/// <param name="mode">加载模式</param>
/// <param name="successCallBack">加载完回调</param>
public void SceneLoadWithPrefab(string sceneName, GameObject loadObj, LoadSceneMode mode, Action successCallBack){}
```

 **loading页面为预制体格式** 

1. 场景加载，只传加载场景名称，loading场景名称默认为Loading，默认single，无回调
```
/// <summary>
/// 场景加载，loading页面路径和名称"Resources/Loading"
/// </summary>
/// <param name="sceneName">加载场景名称</param>
public void SceneLoadWithScene(string sceneName){}
```

2. 场景加载，传加载场景名称，loading场景名称，默认single，无回调
```
/// <summary>
/// 场景加载，loading页面路径和名称"Resources/Loading"
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadSceneName">loading场景名称</param>
public void SceneLoadWithScene(string sceneName, string loadSceneName){}
```

3.场景加载，传加载场景名称，loading场景名称，加载模式，无回调
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面路径</param>
/// <param name="mode">加载模式</param>
public void SceneLoadWithScene(string sceneName, string loadSceneName, LoadSceneMode mode){}
```

4.场景加载，传加载场景名称，loading场景名称，加载模式，回调函数
```
/// <summary>
/// 场景加载
/// </summary>
/// <param name="sceneName">加载场景名称</param>
/// <param name="loadObjPath">loading页面路径</param>
/// <param name="mode">加载模式</param>
/// <param name="successCallBack">加载完回调</param>
public void SceneLoadWithScene(string sceneName, string loadSceneName, LoadSceneMode mode, Action successCallBack){}
```






#### 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request


#### 特技

1.  使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2.  Gitee 官方博客 [blog.gitee.com](https://blog.gitee.com)
3.  你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解 Gitee 上的优秀开源项目
4.  [GVP](https://gitee.com/gvp) 全称是 Gitee 最有价值开源项目，是综合评定出的优秀开源项目
5.  Gitee 官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6.  Gitee 封面人物是一档用来展示 Gitee 会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)
