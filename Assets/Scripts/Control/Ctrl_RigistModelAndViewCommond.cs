using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;
//注册模型与视图层
public class Ctrl_RigistModelAndViewCommond : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        Facade.RegisterProxy(new Model_GameDataProxy());
        Facade.RegisterMediator(new View_GamPlayingMediator(UnityHelper.FindTheChildNode(GameObject.Find("Canvas(Clone)"), "GamePlayingUI(Clone)").GetComponent<GamePlayingUI>()));
    }
}
