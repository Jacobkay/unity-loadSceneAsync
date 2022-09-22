# Unity可自定义loading页的异步加载工具

#### 介绍
可自定义loading页，prefab和scene都可以，获取当前加载进度，场景异步加载


#### 安装教程

1.  下载代码，引入到工程中，核心脚本为SceneLoadTool
2.  单例类，直接调用接口，传入对应参数即可实现场景异步加载

#### 使用说明

API：
1.  `SceneLoadTool.Instance.SceneLoadWithPrefab("Main", loading, UnityEngine.SceneManagement.LoadSceneMode.Single, () => { Debug.LogError("prefabSingle加载回调"); });`
2.  xxxx
3.  xxxx

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
