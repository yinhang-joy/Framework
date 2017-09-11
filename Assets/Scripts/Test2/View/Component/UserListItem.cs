using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SUIFW;
using PureMVC.Patterns;

public class UserListItem : MonoBehaviour {


    private Text TxtUserName;
    private Text TxtGender;
    private Text TxtDepartMent;
    private Text TxtTel;
    private Text TxtEmail;
    private Toggle _Toggle;
    private UserVO _CurrentUser;
    private void Awake()
    {
        TxtUserName = UnityHelper.FindTheChildNode(gameObject, "Txt_UserName").GetComponent<Text>();
        TxtGender = UnityHelper.FindTheChildNode(gameObject, "Txt_Gender").GetComponent<Text>();
        TxtDepartMent = UnityHelper.FindTheChildNode(gameObject, "Txt_Dep").GetComponent<Text>();
        TxtTel = UnityHelper.FindTheChildNode(gameObject, "Txt_Tel").GetComponent<Text>();
        TxtEmail = UnityHelper.FindTheChildNode(gameObject, "Txt_Email").GetComponent<Text>();
        _Toggle = GetComponent<Toggle>();
    }
    private void Start()
    {
        _Toggle.onValueChanged.AddListener(OnValuesChangByToggle);
    }
    public void SetUserListItemInfo(UserVO user)
    {
        _CurrentUser = user;
        this.TxtUserName.text = user.UserName;
        TxtGender.text = user.Gender == true ? "男" : "女";
        TxtDepartMent.text = user.Department;
        TxtTel.text = user.TelePhone;
        TxtEmail.text = user.Email;
    }
    void OnValuesChangByToggle(bool isSelect)
    {
        if (isSelect)
        {
            Facade.Instance.SendNotification(Test2Const.Msg_SelectUserInfoByCtrlToUserListMediator, _CurrentUser);
        }
    }
    // Use this for initialization

}
