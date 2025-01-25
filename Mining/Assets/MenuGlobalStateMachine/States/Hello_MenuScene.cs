using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;

    private IControlGlobalStateMachine controllerGlobalStateMachine;

    public Hello_MenuScene(IControlGlobalStateMachine controllerGlobalStateMachine, UIMainMenuRoot sceneRoot)
    {
        this.controllerGlobalStateMachine = controllerGlobalStateMachine;
        this.sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        sceneRoot.OnGoToShop += ChangeStateToMain;

        sceneRoot.OpenMainPanel();
    }

    public void ExitState()
    {
        sceneRoot.OnGoToShop -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        controllerGlobalStateMachine.SetState(controllerGlobalStateMachine.GetState<Main_MenuScene>());
    }
}
