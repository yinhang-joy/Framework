using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
/// <summary>
/// 数据控制类
/// 功能：属于“控制层”，接收玩家的输入(或者视图层发来的输入消息)，进行处理
/// </summary>
public class DataCommand : SimpleCommand {

    /// <summary>
    /// 执行方法
    /// </summary>
    /// <param name="notification"></param>
    public override void Execute(INotification notification)
    {
        //调用数据层的“增加等级”的方法
        DataProxy datapro = (DataProxy)Facade.RetrieveProxy(DataProxy.NAME); //检索到从Facade注册的代理类，
        datapro.AddLevel(10);
    }
    
}
