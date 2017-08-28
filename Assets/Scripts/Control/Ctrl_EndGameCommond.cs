using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_EndGameCommond : SimpleCommand {

    public override void Execute(INotification notification)
    {
        //游戏停止运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().StopGame();
        UnityHelper.FindTheChildNode(GameObject.Find("MainGameScene"), "LandGroup").gameObject.GetComponent<PipeMovingControl>().EndGame();
    }
}
