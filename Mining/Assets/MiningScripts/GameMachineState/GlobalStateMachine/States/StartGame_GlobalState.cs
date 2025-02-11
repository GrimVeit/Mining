using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private IControlGlobalStateMachine controlMachine;

    private ShipInfoPresenter shipInfoPresenter;

    public StartGame_GlobalState(
        IControlGlobalStateMachine controlMachine,
        UIMiniGameSceneRoot sceneRoot,
        ShipInfoPresenter shipInfoPresenter)
    {
        this.controlMachine = controlMachine;
        this.sceneRoot = sceneRoot;
        this.shipInfoPresenter = shipInfoPresenter;
    }

    public void EnterState()
    {
        shipInfoPresenter.OnPlayGame += ChangeStateToMain;

        sceneRoot.OpenStartGamePanel();
    }

    public void ExitState()
    {
        shipInfoPresenter.OnPlayGame -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        controlMachine.SetState(controlMachine.GetState<Main_GlobalState>());
    }
}
