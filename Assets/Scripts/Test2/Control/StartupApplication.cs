using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class StartupApplication : SimpleCommand {

    private EmployeeInfo emplpyeeInfo;
    public override void Execute(INotification notification)
    {
        emplpyeeInfo = notification.Body as EmployeeInfo;
        SendNotification(Test2Const.Msg_InitUserFormMediator, emplpyeeInfo.userForm);
        SendNotification(Test2Const.Msg_InitUserListMediator,emplpyeeInfo.userList);
    }
}
