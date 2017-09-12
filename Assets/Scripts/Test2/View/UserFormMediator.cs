using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;

/// <summary>
/// 用户类型
/// </summary>
public enum UserFromType
{
    //创建（用户）
    Create,
    //更新
    Update
}

public class UserFormMediator : Mediator {

    public new const string NAME = "UserFormMediator";
    private UserProxy userProxy;
    private UserFromType userFromType= UserFromType.Create;
    public UserForm userForm
    {
        get{
            return base.ViewComponent as UserForm;
        }
    }
    public UserFormMediator() : base(NAME)
    {

    }
    void InitUserFormMediator(UserForm userform)
    {
        base.ViewComponent = userform;
        base.m_mediatorName = NAME;
        userform.BtnConfirmAction += BtnConfirmActionClick;
    }
    public override void OnRegister()
    {
        userProxy = Facade.RetrieveProxy(UserProxy.NAME) as UserProxy;
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add(Test2Const.Msg_SelUserInfoByUserListMedToUserFormMed);
        list.Add(Test2Const.Msg_InitUserFormMediator);
        list.Add(Test2Const.Msg_ClearUserInfo);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Test2Const.Msg_InitUserFormMediator:
                UserForm userform = notification.Body as UserForm;
                InitUserFormMediator(userform);
                break;
            case Test2Const.Msg_ClearUserInfo:
                userFromType = UserFromType.Create;
                userForm.CleanForm();
                break;
            case Test2Const.Msg_SelUserInfoByUserListMedToUserFormMed:
                userFromType = UserFromType.Update;
                UserVO user = notification.Body as UserVO;
                userForm.SetUserFormInfo(user);
                break;
        }
    }
    void BtnConfirmActionClick()
    {
        if (userFromType==UserFromType.Create)
        {
            SendNotification(Test2Const.Msg_AddNewUserInfoToUserListMed,userForm._UserVO);
        }
        if (userFromType==UserFromType.Update)
        {
            SendNotification(Test2Const.Msg_UpdateUserInfoToUserListMed,userForm._UserVO);
        }
    }
    
}
