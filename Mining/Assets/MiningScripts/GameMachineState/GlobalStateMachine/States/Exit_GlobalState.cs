using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private PlanetRocketVisualPresenter planetRocketVisualPresenter;

    private IControlGlobalStateMachine controlMachine;

    public Exit_GlobalState(
        IControlGlobalStateMachine controlMachine,
        UIMiniGameSceneRoot sceneRoot,
        PlanetRocketVisualPresenter rocketVisualPresenter)
    {
        this.controlMachine = controlMachine;
        this.sceneRoot = sceneRoot;
        this.planetRocketVisualPresenter = rocketVisualPresenter;
    }

    public void EnterState()
    {
        sceneRoot.OnClickToCancelExit += ChangeStateToMain;

        sceneRoot.CloseGameplayButtonsPanel();
        sceneRoot.OpenExitPanel();
        planetRocketVisualPresenter.SelectDefault();
    }

    public void ExitState()
    {
        sceneRoot.OnClickToCancelExit -= ChangeStateToMain;

        sceneRoot.CloseExitPanel();
    }

    private void ChangeStateToMain()
    {
        sceneRoot.OpenGameplayButtonsPanel();

        controlMachine.SetState(controlMachine.GetState<Main_GlobalState>());
    }
}
