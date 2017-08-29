using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using SUIFW;
public class ApplicationFacade : Facade {
    public ApplicationFacade()
    {
        //注册核心的“命令”
        RegisterCommand("Reg_StartGameCommand",typeof(Ctrl_StartGameCommond));
        RegisterCommand("Reg_EndGameCommond", typeof(Ctrl_EndGameCommond));
        AddGameObjectScripts();
        //添加游戏对象脚本
    }
    private void AddGameObjectScripts()
    {
        GameObject goRoot = GameObject.Find("MainGameScene");
        UnityHelper.FindTheChildNode(goRoot, "LandGroup").gameObject.AddComponent<LandMovingControl>();
        UnityHelper.FindTheChildNode(goRoot, "PipeGroup").gameObject.AddComponent<PipeMovingControl>();
        GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerControl>();
        goRoot.AddComponent<Ctrl_GetTimer>();
        goRoot.AddComponent<Ctrl_Golds>();
    }
}