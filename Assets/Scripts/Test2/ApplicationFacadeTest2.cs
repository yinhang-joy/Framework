using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFacadeTest2 : Facade {

    public new static IFacade Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_staticSyncRoot)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ApplicationFacade();
                    }
                }
            }
            return m_instance;
        }

    }
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(Test2Const.Com_InitMediator,typeof(StartupApplication));
    }
    protected override void InitializeModel()
    {
        RegisterProxy( new UserProxy());
    }
    protected override void InitializeView()
    {
        base.InitializeView();
    }
}
