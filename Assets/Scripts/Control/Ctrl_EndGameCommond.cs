using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_EndGameCommond : SimpleCommand {

    public override void Execute(INotification notification)
    {
        //脚本停止运行
        StopScriptRuning();
        //关闭当前UI窗体，回到玩家指导
        CloseCurrentUI();
        //保存当前最高分
        Model_GameDataProxy proxy =  Facade.RetrieveProxy("Model_GameDataProxy") as Model_GameDataProxy;
        proxy.SetMaxScore();
    }
    private void StopScriptRuning()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().StopGame();
        UnityHelper.FindTheChildNode(GameObject.Find("MainGameScene"), "PipeGroup").gameObject.GetComponent<PipeMovingControl>().EndGame();
        GameObject.Find("MainGameScene").GetComponent<Ctrl_GetTimer>().StopGame();
        GameObject.Find("MainGameScene").GetComponent<Ctrl_Golds>().StopGame();

    }
    private void CloseCurrentUI()
    {
        UIManager.GetInstance().CloseUIForms("GamePlayingUI");
    }
}
