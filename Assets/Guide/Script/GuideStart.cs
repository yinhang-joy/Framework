using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class GuideStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.GetInstance().ShowUIForms("MainUIPanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
