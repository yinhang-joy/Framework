using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
/// <summary>
/// PureMVC项目全局控制类
/// </summary>
public class AppFacade : Facade {
   
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="goRoot">UI界面的根节点</param>
    public AppFacade(GameObject goRoot)
    {
        /*MVC三层的关联绑定*/

        //控制层注册("命令消息"与控制层类的对应关系建立绑定)(当发送Reg_StartDataCommand消息时执行DataCommand)
        RegisterCommand("Reg_StartDataCommand", typeof(DataCommand));
        //视图层注册
        RegisterMediator(new DataMediator(goRoot));
        //模型层注册
        RegisterProxy(new DataProxy());
    }
}
