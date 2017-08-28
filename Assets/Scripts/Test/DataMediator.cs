using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Interfaces;
/// <summary>
/// 视图展示
/// 功能：属于“视图层”显示玩家ui页面
/// </summary>
public class DataMediator : Mediator {
    //定义本类的名称
    public new const string NAME = "DataMediator";
    //定义控件
    private Text TxtLevel;
    private Button BtnDisplayLevelNum;
    

    public DataMediator(GameObject goRootNode)
    {
        //确定控件
        TxtLevel = goRootNode.transform.Find("Text").GetComponent<Text>();
        BtnDisplayLevelNum = goRootNode.transform.Find("BtnCount").GetComponent<Button>();
        BtnDisplayLevelNum.onClick.AddListener(OnClickAddLevel);
    }
    /// <summary>
    /// 定义一个点击事件
    /// </summary>
    private void OnClickAddLevel()
    {
        //定义消息，发送“控制层”
        SendNotification("Reg_StartDataCommand");
    }

    /// <summary>
    /// 本视图层允许接受的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> listResult = new List<string>();
        
        //可以接受的消息（集合）
        listResult.Add("Msg_AddLevel");
        return listResult;
    }
    /// <summary>
    /// 处理所有其他类，发给本类允许处理的消息
    /// </summary> 
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case "Msg_AddLevel":
                //把模型层发来的数据显示给控件
                MyData myData = notification.Body as MyData;
                TxtLevel.text = myData.Level.ToString();
                break;
        }
    }
    
}
