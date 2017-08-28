using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Facade.Instance.SendNotification("Reg_EndGameCommond");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
