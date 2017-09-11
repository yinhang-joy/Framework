using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;

public class UserListMedirto : Mediator {

    public new const string NAME = "UserListMedirto";
    private UserProxy userProxy;
    private UserVO _CurrentSelectUserRecord;
    public UserList userList
    {
        get
        {
            return  base.ViewComponent as UserList;
        }
    }
    public override void OnRegister()
    {
        userProxy = Facade.RetrieveProxy(UserProxy.NAME) as UserProxy;
    }

    public UserListMedirto() : base(NAME)
    {

    }

    public void InitUserList(UserList userlist)
    {
        if (userList == null) return;
        base.m_mediatorName = NAME;
        base.ViewComponent = userlist;
        userList.ShowUserListInfo(userProxy.Users);
        userList.BtnDeleteUserAction += HandleDeleteUser;
        userList.BtnNewUserAction += HandleAddUser;
    }
    

    public override IList<string> ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(Test2Const.Msg_UpdateUserInfoToUserListMed);
        list.Add(Test2Const.Msg_AddNewUserInfoToUserListMed);
        list.Add(Test2Const.Msg_SelectUserInfoByCtrlToUserListMediator);
        list.Add(Test2Const.Msg_InitUserListMediator);
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case Test2Const.Com_InitMediator:
                UserList userlist = notification.Body as UserList;
                InitUserList(userlist);
                break;
            case Test2Const.Msg_SelectUserInfoByCtrlToUserListMediator:
                UserVO user = notification.Body as UserVO;
                HandelSelctUserInfo(user);
                break;
            case Test2Const.Msg_UpdateUserInfoToUserListMed:
                UserVO userUpdata = notification.Body as UserVO;
                SubmitUpdataUserInfo(userUpdata);
                break;
            case Test2Const.Msg_AddNewUserInfoToUserListMed:
                UserVO userAddNew = notification.Body as UserVO;
                SubmitAddNewUserItem(userAddNew);
                break;
        }
    }
    /// <summary>
    /// 选中信息通知UserInfo改变信息
    /// </summary>
    /// <param name="user"></param>
    void HandelSelctUserInfo(UserVO user)
    {
        if (user!=null)
        {
            _CurrentSelectUserRecord = user;
            SendNotification(Test2Const.Msg_SelUserInfoByUserListMedToUserFormMed, user);
        }
    }
    /// <summary>
    /// 删除信息
    /// </summary>
    void HandleDeleteUser()
    {
        if (_CurrentSelectUserRecord!=null)
        {
            SendNotification(Test2Const.Msg_ClearUserInfo);
            userProxy.RemoveUserItem(_CurrentSelectUserRecord);
            userList.ShowUserListInfo(userProxy.Users);
        }
    }

    /// <summary>
    /// 按钮点击添加信息
    /// </summary>
    void HandleAddUser()
    {
        SendNotification(Test2Const.Msg_ClearUserInfo);
    }
    /// <summary>
    /// 提交修改信息UserList修改
    /// </summary>
    /// <param name="user"></param>
    void SubmitUpdataUserInfo(UserVO user)
    {
        if (user!=null)
        {
            userProxy.UpdateUserItem(user);
            SendNotification(Test2Const.Msg_SelUserInfoByUserListMedToUserFormMed,user);
        }
    }/// <summary>
    /// 用户添加完成时UserList修改
    /// </summary>
    void SubmitAddNewUserItem(UserVO user)
    {
        if (user!=null)
        {
            userProxy.Users.Add(user);
            userList.ShowUserListInfo(userProxy.Users);
        }
    }
}
