using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 数据代理类
/// 功能：模型层 数据的操作
/// </summary>
public class DataProxy : Proxy {
    /// <summary>
    /// 声明本类的名称
    /// </summary>
    public new const string NAME = "DataProxy";
    /// <summary>
    /// 引用“实体类”
    /// </summary>
    private MyData _MyData = null;
    /// <summary>
    /// 构造器
    /// </summary>
    public DataProxy():base(NAME)
    {
        _MyData = new MyData();
    }
    /// <summary>
    /// 增加玩家等级
    /// </summary>
    public void AddLevel(int addNumber)
    {
        //把参数累加到“实体类中”
        _MyData.Level += addNumber;
        //把变化了的数据，发送给“视图层”
        SendNotification("Msg_AddLevel", _MyData);
    }
}
