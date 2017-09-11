using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovingControl : MonoBehaviour {

    public float MovingSpeed = 1f;
    private Vector2 VecStartPosition;
    public bool IsStartGame = false;
    // Use this for initialization
    void Start()
    {
        VecStartPosition = this.transform.position;
    }
    public void StartGame()
    {
        IsStartGame = true;
    }
    public void EndGame()
    {
        IsStartGame = false;
        //游戏结束管道复位
        ResetPipesPosition();
    }
    private void ResetPipesPosition()
    {
        transform.position = VecStartPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsStartGame)
        {
            //管道组循环移动
            if (this.transform.position.x < -6)
            {
                transform.position = VecStartPosition;
            }
            this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * MovingSpeed);
        }
      
    }
}
