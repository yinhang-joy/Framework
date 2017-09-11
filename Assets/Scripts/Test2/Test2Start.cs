using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Facade facade = ApplicationFacadeTest2.Instance as Facade;
        facade.SendNotification(Test2Const.Com_InitMediator);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
