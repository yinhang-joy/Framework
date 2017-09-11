using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserVO {

    //字段
    private string _FirstName;
    private string _LastName;
    private bool _Gender;
    private string _Department;
    private string _TelePhone;
    private string _Email;
    /// <summary>
    /// 数据是否有效
    /// </summary>
    public bool IsValid
    {
        get { return !string.IsNullOrEmpty(_Department) && !string.IsNullOrEmpty(UserName); }
    }

    public UserVO()
    {

    }
    public UserVO(string firstname,string lastname,bool gender,string department,string telephone,string email)
    {
        this._FirstName = firstname;
        this._LastName = lastname;
        this._Gender = gender;
        this._Department = department;
        this._TelePhone = telephone;
        this._Email = email;
    }
    public string UserName
    {
        get { return _FirstName + _LastName; }
    }
    public string FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            _FirstName = value;
        }
     
    }

    public string LastName
    {
        get
        {
            return _LastName;
        }
        set
        {
            _LastName = value;
        }
    }

    public bool Gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    
    }

    public string Department
    {
        get
        {
            return _Department;
        }

        set
        {
            _Department = value;
        }
    }

    public string TelePhone
    {
        get
        {
            return _TelePhone;
        }

        set
        {
            _TelePhone = value;
        }
    }

    public string Email
    {
        get
        {
            return _Email;
        }

        set
        {
            _Email = value;
        }
    }
    /// <summary>
    /// 对象比较
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        bool boolResult = false;
        UserVO otherVO = null;
        otherVO = obj as UserVO;
        if (otherVO!=null)
        {
            if (this.UserName==otherVO.UserName)//名字相同就返回真
            {
                boolResult = true;
            }
        }
        return boolResult;
    }
}
