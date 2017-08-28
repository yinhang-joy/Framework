using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class Ctrl_RegStartGameCommond : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        //游戏重新运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().StartGame();
    }
}
