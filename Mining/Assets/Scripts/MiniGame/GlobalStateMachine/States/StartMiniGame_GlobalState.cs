using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame_GlobalState : IGlobalState
{
    private IControlGlobalStateMachine controlGlobalStateMachine;

    private UIMiniGameSceneRoot sceneRoot;
    private BasketPresenter basketPresenter;
    private TimerPresenter timerPresenter;

    public StartMiniGame_GlobalState(IControlGlobalStateMachine controlGlobalStateMachine, UIMiniGameSceneRoot sceneRoot, BasketPresenter basketPresenter, TimerPresenter timerPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.basketPresenter = basketPresenter;
        this.timerPresenter = timerPresenter;
    }

    public void EnterState()
    {
        timerPresenter.OnStopTimer += ChangeStateToMiniGame;

        timerPresenter.ActivateTimer(3);
        basketPresenter.Start();
        sceneRoot.OpenMainPanel();
        sceneRoot.OpenFooterPanel();
    }

    public void ExitState()
    {
        timerPresenter.OnStopTimer -= ChangeStateToMiniGame;

        timerPresenter.DeactivateTimer();
    }

    private void ChangeStateToMiniGame()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<MiniGame_GlobalState>());
    }
}
