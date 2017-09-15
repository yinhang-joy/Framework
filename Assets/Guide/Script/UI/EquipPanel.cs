using UnityEngine;
using System.Collections;
using SUIFW;

public class EquipPanel : BaseUIForm {

	void Start () 
    {
        EventTriggerListener.GetListener(transform.Find("Button").gameObject).onPointerClick +=
            (go) => { CloseUIForm(); };
        EventTriggerListener.GetListener(transform.Find("Button (1)").gameObject).onPointerClick +=
            (go) => { Debug.Log("装上"); };
        EventTriggerListener.GetListener(transform.Find("Button (2)").gameObject).onPointerClick +=
            (go) => { Debug.Log("卸下"); };
        EventTriggerListener.GetListener(transform.Find("Image/Button").gameObject).onPointerClick +=
            (go) => { Debug.Log("查看属性"); };
	}
	
}
