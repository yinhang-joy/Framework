using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public float fSpeed = 3;
    public Vector3 vecTarget;
    //Quaternion quat = Quaternion.identity;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        Quaternion quat = Quaternion.identity;

        quat = transform.rotation * Quaternion.Euler(vecTarget);
        print("物体自身角度:" + transform.eulerAngles + "旋转角度:" + vecTarget + "目标角度：" + quat.eulerAngles);
        Vector3 vec = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime * fSpeed).eulerAngles;
        transform.localEulerAngles = vec;
    }
}
