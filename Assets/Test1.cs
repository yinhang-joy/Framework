using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour {

    public Button go;

    private void Awake()
    {

    }
    public void show()
    {
        Debug.Log("123");
    }
    private void Update()
    {
        go.OnSubmit(null);
    }
}
