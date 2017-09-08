using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Test : MonoBehaviour {

    public float fSpeed = 3;
    public Vector3 vecTarget;
    //Quaternion quat = Quaternion.identity;
    // Use this for initialization
    private void Awake()
    {
        int[] arr = {6,3,2,5,4,8,1 };
        Show(arr);
    }

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
    void Show(int [] arr)
    {
        int temp;
        for (int i = arr.Length - 1; i >0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[j]<arr[j+1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        for (int i = 0; i < arr.Length; i++)
        {
            print(arr[i]);
        }
    }

}
