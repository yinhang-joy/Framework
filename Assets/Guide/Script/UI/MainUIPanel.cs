using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SUIFW;

public class MainUIPanel : BaseUIForm {

    void Awake()
    {
        EventTriggerListener.GetListener(UnityHelper.FindTheChildNode(gameObject,"Button").gameObject).onPointerClick +=
            (go) => { UIManager.GetInstance().ShowUIForms("EquipPanel"); };
        EventTriggerListener.GetListener(UnityHelper.FindTheChildNode(gameObject, "Button (1)").gameObject).onPointerClick +=
            (go) => { UIManager.GetInstance().ShowUIForms("BagPanel"); };
        EventTriggerListener.GetListener(UnityHelper.FindTheChildNode(gameObject, "Button (2)").gameObject).onPointerClick +=
            (go) => { GuideManager.Instance.Next(); };
        EventTriggerListener.GetListener(UnityHelper.FindTheChildNode(gameObject, "Button (3)").gameObject).onPointerClick +=
            (go) => { GuideManager.Instance.Next(); };

        GuideManager.Instance.Init(); 
    }

}
