using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
//模型的实例
public class Model_GameDataProxy : Proxy {
    public new const string NAME = "Model_GameDataProxy";
    private Model_GameData GameData;
    public Model_GameDataProxy() : base(NAME)
    {
        GameData = new Model_GameData();
        //得到最高分
        GameData.MaxScore = PlayerPrefs.GetInt("MaxScore");
        SendNotification("Msg_DisplayGameInfo", GameData);
    }
    public void AddGameTime()
    {
        ++GameData.GameTime;
        SendNotification("Msg_DisplayGameInfo", GameData);
    }
    public void AddScore()
    {
        ++GameData.Score;
        GetMaxScore();
        SendNotification("Msg_DisplayGameInfo", GameData);
    }
    public int GetMaxScore()
    {
        if (GameData.Score> GameData.MaxScore)
        {
            GameData.MaxScore = GameData.Score;
        }
        return GameData.MaxScore;
    }
    public void SetMaxScore()
    {
        if (GameData.Score > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", GameData.Score);
        }
    }

}
