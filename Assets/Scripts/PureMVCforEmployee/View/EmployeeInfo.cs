using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeInfo : MonoBehaviour {

    public UserForm userForm;
    public UserList userList;
    private void Awake()
    {
        userForm = FindObjectOfType<UserForm>();
        userList = FindObjectOfType<UserList>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
