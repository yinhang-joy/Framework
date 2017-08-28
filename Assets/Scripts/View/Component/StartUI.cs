using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
public class StartUI : BaseUIForm
{
    private void Awake()
    {
        RigisterButtonObjectEvent("Btn_Play", p=>{ OpenUIForm("GameGuideUI"); });
    }
    private void Start()
    {
        new ApplicationFacade();
    }
}
