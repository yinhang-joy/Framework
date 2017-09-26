using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class View_GamPlayingMediator : Mediator {

    private GamePlayingUI View
    {
        get { return (GamePlayingUI)ViewComponent; }
    }

    public new const string NAME = "View_GamPlayingMediator";

    public View_GamPlayingMediator(GamePlayingUI view):base(NAME)
    {
        ViewComponent = view;
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>();
        list.Add("Msg_DisplayGameInfo");
        return list;
    }
    public override void HandleNotification(INotification notification)
    {
        Model_GameData gameData = notification.Body as Model_GameData;
        switch (notification.Name)
        {
            case "Msg_DisplayGameInfo":
                View.UpdataGameInfo(gameData);
                break;
        }
    }
}
