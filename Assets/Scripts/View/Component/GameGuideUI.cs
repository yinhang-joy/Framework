using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
using PureMVC.Patterns;

public class GameGuideUI : BaseUIForm
{
    private void Awake()
    {
        //本窗体类型
        CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
        RigisterButtonObjectEvent("Btn_Tutorial", delegate {
            OpenUIForm("GamePlayingUI");
            //MVC启动
            Facade.Instance.SendNotification("Reg_StartGameCommand");
        });
    }
}
