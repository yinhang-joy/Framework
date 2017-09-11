using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SUIFW;
using System;

public class UserList : MonoBehaviour {
    private Text TxtUserCount;
    private GameObject GridInfo;
    private GameObject BtnNewUser;
    private GameObject BtnDeleteUser;
    public UserListItem UserListItemPrefab;
    public Action BtnNewUserAction;
    public Action BtnDeleteUserAction;
    public List<UserListItem> UserItemList= new List<UserListItem>();
    private void Awake()
    {
        TxtUserCount = UnityHelper.FindTheChildNode(gameObject, "TxtUserCount").GetComponent<Text>();
        GridInfo = UnityHelper.FindTheChildNode(gameObject, "GridInfo").gameObject;
        BtnNewUser = UnityHelper.FindTheChildNode(gameObject, "BtnNewUser").gameObject;
        BtnDeleteUser = UnityHelper.FindTheChildNode(gameObject, "BtnDeleteUser").gameObject;
    }
    // Use this for initialization
    void Start () {
        BtnNewUser.GetComponent<Button>().onClick.AddListener(BtnNewUserClick);
        BtnDeleteUser.GetComponent<Button>().onClick.AddListener(BtnDeleteUserClick);
    }
    public void ShowUserListInfo(List<UserVO> userList)
    {
        ClearItems();
        for (int i = 0; i < userList.Count; i++)
        {
            UserListItem userItem = Instantiate(UserListItemPrefab);
            userItem.transform.parent = GridInfo.transform;
            userItem.transform.localEulerAngles = Vector3.zero;
            userItem.transform.localPosition = Vector3.zero;
            userItem.transform.localScale = Vector3.one;
            userItem.SetUserListItemInfo(userList[i]);
            UserItemList.Add(userItem);
        }
    }
    public void ClearItems()
    {
        for (int i = 0; i < UserItemList.Count; i++)
        {
            Destroy(UserItemList[i]);
        }
        UserItemList.Clear();
    }

    private void BtnNewUserClick()
    {
        if (BtnNewUserAction!=null)
        {
            BtnNewUserAction.Invoke();
        }
    }
    private void BtnDeleteUserClick()
    {
        if (BtnDeleteUserAction!=null)
        {
            BtnDeleteUserAction.Invoke();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
