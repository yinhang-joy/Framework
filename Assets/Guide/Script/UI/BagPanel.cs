using UnityEngine;
using System.Collections;
using SUIFW;

public class BagPanel : BaseUIForm {

	void Start () 
    {
        EventTriggerListener.GetListener(transform.Find("Button").gameObject).onPointerClick +=
            (go) => { CloseUIForm() ; };
        EventTriggerListener.GetListener(transform.Find("Button (1)").gameObject).onPointerClick +=
            (go) => { Debug.Log("整理"); };
	}

}
