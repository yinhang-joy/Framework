using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Const {

    /// <summary>
    /// PureMVC命令消息
    /// </summary>
    public const string Com_InitMediator = "Com_InitMediator";
    //初始化UserList信息
    public const string Msg_InitUserListMediator = "Msg_IniUserListMediator";
    //初始化UserForm信息
    public const string Msg_InitUserFormMediator = "Msg_InitUserFormMediator";
    //增加用户信息
    public const string Msg_AddNewUserInfo = "Msg_AddNewUserInfo";
    //清除用户信息
    public const string Msg_ClearUserInfo = "Msg_ClearUserInfo";
    //发送用户列表Mediator消息，增加用户记录
    public const string Msg_AddNewUserInfoToUserListMed = "Msg_AddNewUserInfoToUserListMed";
    //发送用户列表Mediator消息_更新用户记录
    public const string Msg_UpdateUserInfoToUserListMed = "Msg_UpdateUserInfoToUserListMed";


    //发送到列表信息Mediator 关于用户选择信息
    public const string Msg_SelectUserInfoByCtrlToUserListMediator = "Msg_SelectUserInfoByCtrlToUserListMediator";
    //发送到“用户窗体”Mediator类。
    public const string Msg_SelUserInfoByUserListMedToUserFormMed = "Msg_SelUserInfoByUserListMedToUserFormMed";
}
