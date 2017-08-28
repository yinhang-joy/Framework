using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMovingControl : MonoBehaviour {

    public float MovingSpeed = 1f;
    private Vector2 VecStartPosition;
	// Use this for initialization
	void Start () {
        VecStartPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //陆地循环移动
        if (this.transform.position.x<-2)
        {
            transform.position = VecStartPosition;
        }
        this.gameObject.transform.Translate(Vector2.left*Time.deltaTime*MovingSpeed);
	}
}
