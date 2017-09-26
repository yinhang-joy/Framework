using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProxy : Proxy {

    public new const string NAME = "UserProxy";
    public UserVO _CurrentSelectUserRecord;
    public List<UserVO> Users
    {
        get { return base.Data as List<UserVO>; }
    }
    public UserProxy():base(NAME,new List<UserVO>())
    {
        AddUserItem(new UserVO("陆","毅",true,"技术研发","136456465465","123123@qq.com"));
        AddUserItem(new UserVO("沙","宝亮", true, "销售部", "136456465465", "123123@qq.com"));

    }
    /// <summary>
    /// 增加item
    /// </summary>
    /// <param name="user"></param>
    public void AddUserItem(UserVO user)
    {
        if (Users!=null)
        {
            Users.Add(user);
        }
    }
    /// <summary>
    /// 更新item
    /// </summary>
    /// <param name="user"></param>
    public void UpdateUserItem(UserVO user)
    {
        if (Users != null)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Equals(_CurrentSelectUserRecord))
                {
                    Users[i] = user;
                    return;
                }
            }
        }
    }
    /// <summary>
    /// 删除Item
    /// </summary>
    /// <param name="user"></param>
    public void RemoveUserItem(UserVO user)
    {
        if (Users!=null&&Users.Contains(user))
        {
            Users.Remove(user);
        }
    }
}
