using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {
    //升力
    public float UpPower=3;
    //2D刚体
    private Rigidbody2D rigibody2D;
    //触角原始位置
    private Vector2 _VecStartPosition;
    //游戏是否开始
    private bool _IsGameStart;
    private void Awake()
    {
        _VecStartPosition = this.transform.position;
        rigibody2D = GetComponent<Rigidbody2D>();
        DisableRigibody2D();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_IsGameStart)
        {
            if (Input.GetButton("Fire1"))
            {
                rigibody2D.velocity = Vector2.up*UpPower;
            }
        }
	}
    //游戏开始
    public void StartGame()
    {
        _IsGameStart = true;
        this.rigibody2D.isKinematic = false;
    }
    public void StopGame()
    {
        _IsGameStart = false;
        this.transform.position = _VecStartPosition;
        DisableRigibody2D();
    }
    //游戏结束
    /// <summary>
    /// 禁用2D刚体
    /// </summary>
    private void DisableRigibody2D()
    {
        rigibody2D.isKinematic = true;
    }
}
