using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_GetTimer : MonoBehaviour {
    //模型代理
    public Model_GameDataProxy GamedataProxy;
    private bool IsStartGame=false;
	// Use this for initialization
	void Start () {
        //启动协程,每隔一秒钟往puremvc模型层发送一个消息
        StartCoroutine(GetTimer());
    }
    public void StartGame()
    {
        //得到模型层类的对象实例
        GamedataProxy = Facade.Instance.RetrieveProxy("Model_GameDataProxy") as Model_GameDataProxy;
        IsStartGame = true;
    }
    public void StopGame()
    {
        IsStartGame = false;
    }
	IEnumerator GetTimer()
    {
        //yield return new WaitForEndOfFrame();
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (GamedataProxy!=null&&IsStartGame==true)
            {
                GamedataProxy.AddGameTime();
            }
        }
    }
	// Update is called once per frame
	void Update () {
        
	}
}
