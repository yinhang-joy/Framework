using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
using UnityEngine.UI;
using System;
using PureMVC.Patterns;

public class UserForm : MonoBehaviour {
    private InputField Item_FirstName;
    private InputField Item_LastName;
    private Toggle Tog_Male;
    private Toggle Tog_Famale;
    private InputField Item_Department;
    private InputField Item_Tel;
    private InputField Item_Email;
    private Button BtnConfirm;
    public Action BtnConfirmAction;

    public UserVO _UserVO { get; private set; }

    private void Awake()
    {
        Item_FirstName = UnityHelper.FindTheChildNode(gameObject, "Item_FirstName_Text").GetComponent<InputField>();
        Item_LastName = UnityHelper.FindTheChildNode(gameObject, "Item_LastName_Text").GetComponent<InputField>();
        Tog_Male = UnityHelper.FindTheChildNode(gameObject, "Tog_Male").GetComponent<Toggle>();
        Tog_Famale = UnityHelper.FindTheChildNode(gameObject, "Tog_Famale").GetComponent<Toggle>();
        Item_Department = UnityHelper.FindTheChildNode(gameObject, "Item_Department_Text").GetComponent<InputField>();
        Item_Tel = UnityHelper.FindTheChildNode(gameObject, "Item_Tel_Text").GetComponent<InputField>();
        Item_Email = UnityHelper.FindTheChildNode(gameObject, "Item_Email_Text").GetComponent<InputField>();
        BtnConfirm = UnityHelper.FindTheChildNode(gameObject, "BtnConfirm").GetComponent<Button>();
    }
    // Use this for initialization
    void Start () {
        BtnConfirm.onClick.AddListener(BtnConfirmClick);
	}
    private void BtnConfirmClick() {
        if (BtnConfirmAction!=null)
        {
            if (CheckUserInfoIsStandard())
            {
                BtnConfirmAction.Invoke();
            }
        }
    }
    public void SetUserFormInfo(UserVO user)
    {
        if (user == null) return;
        Item_FirstName.text = user.FirstName;
        Item_LastName.text = user.LastName;
        if (user.Gender)
        {
            Tog_Male.isOn = true;
            Tog_Famale.isOn = false;
        }
        else
        {
            Tog_Famale.isOn = true;
            Tog_Male.isOn = false;
        }
        Item_Department.text = user.Department;
        Item_Tel.text = user.TelePhone;
        Item_Email.text = user.Email;
    }
    public void CleanForm()
    {
        Item_FirstName.text = "";
        Item_FirstName.text = "";
        Item_LastName.text = "";
        Tog_Male.isOn = true;
        Item_Department.text = "";
        Item_Tel.text = "";
        Item_Email.text = "";
    }
    /// <summary>
    /// 检查信息是否有效
    /// </summary>
    /// <returns></returns>
    private bool CheckUserInfoIsStandard()
    {
        _UserVO = new UserVO();
        //获取数据 
        _UserVO.FirstName = Item_FirstName.text;
        _UserVO.LastName = Item_LastName.text;
        if (Tog_Male.isOn)
        {
            _UserVO.Gender = true;
        }
        else if (Tog_Famale.isOn)
        {
            _UserVO.Gender = false;
        }
        _UserVO.Department = Item_Department.text;
        _UserVO.TelePhone= Item_Tel.text;
        _UserVO.Email = Item_Email.text;
        //数据检查
        if (_UserVO.IsValid)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
