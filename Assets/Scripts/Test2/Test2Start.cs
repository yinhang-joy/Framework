using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Start : MonoBehaviour {
    public EmployeeInfo employeeInfo;
    private void Awake()
    {
        employeeInfo = FindObjectOfType<EmployeeInfo>();
    }
    // Use this for initialization
    void Start () {
        Facade facade = ApplicationFacadeTest2.Instance as Facade;
        facade.SendNotification(Test2Const.Com_InitMediator, employeeInfo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
