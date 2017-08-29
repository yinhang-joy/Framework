using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
using UnityEngine.UI;

public class GamePlayingUI : BaseUIForm
{
    private Text GameTimer;
    private Text MAXScore;
    private Text CurScore;
    private void Awake()
    {
        CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
        GameTimer = UnityHelper.FindTheChildNode(this.gameObject, "Timer").GetComponent<Text>();
        MAXScore = UnityHelper.FindTheChildNode(this.gameObject, "MAXScore").GetComponent<Text>();
        CurScore = UnityHelper.FindTheChildNode(this.gameObject, "CurScore").GetComponent<Text>();
    }
    
    public void UpdataGameInfo(Model_GameData gameData)
    {
        GameTimer.text = gameData.GameTime.ToString();
        MAXScore.text = gameData.MaxScore.ToString();
        CurScore.text = gameData.Score.ToString();
    }
}
