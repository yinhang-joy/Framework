using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_RegStartGameCommond : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        //游戏重新运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().StartGame();
        UnityHelper.FindTheChildNode(GameObject.Find("MainGameScene"), "PipeGroup").GetComponent<PipeMovingControl>().StartGame();
        GameObject.Find("MainGameScene").GetComponent<Ctrl_GetTimer>().StartGame();
        GameObject.Find("MainGameScene").GetComponent<Ctrl_Golds>().StartGame();
    }
}
