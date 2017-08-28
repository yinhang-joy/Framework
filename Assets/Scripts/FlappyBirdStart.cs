using SUIFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdStart : MonoBehaviour {
    private void Start()
    {
        UIManager.GetInstance().ShowUIForms("StartUI");
    }
}
