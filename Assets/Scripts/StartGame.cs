using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //启动PureMvc框架
       AppFacade facade = new AppFacade(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
