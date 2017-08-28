using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
public class Ctrl_StartGameCommond : MacroCommand
{

    protected override void InitializeMacroCommand()
    {
        //注册模型与试图Command
        AddSubCommand(typeof(Ctrl_RigistModelAndViewCommond));
        AddSubCommand(typeof(Ctrl_RegStartGameCommond));
    }
}
