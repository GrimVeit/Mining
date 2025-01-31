using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;

    private BasketPresenter basketPresenter;
    private EggCatcherPresenter eggCatcherPresenter;
    private ScorePresenter scorePresenter;
    private PointAnimationPresenter pointAnimationPresenter;

    private IControlGlobalStateMachine machineControl;

    public MiniGame_GlobalState(
        IControlGlobalStateMachine machineControl, 
        UIMiniGameSceneRoot sceneRoot, 
        BasketPresenter basketPresenter, 
        EggCatcherPresenter eggCatcherPresenter, 
        ScorePresenter scorePresenter,
        PointAnimationPresenter pointAnimationPresenter)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
        this.basketPresenter = basketPresenter;
        this.eggCatcherPresenter = eggCatcherPresenter;
        this.scorePresenter = scorePresenter;
        this.pointAnimationPresenter = pointAnimationPresenter;
    }

    public void EnterState()
    {
        scorePresenter.OnGameFailed += ChangeStateToFail;
        scorePresenter.OnGameWinned += ChangeStateToWin;
        eggCatcherPresenter.OnEggDown += scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin += scorePresenter.AddScore;
        eggCatcherPresenter.OnEggDown_Position += pointAnimationPresenter.PlayAnimation;

        eggCatcherPresenter.SetTimerSpawnerData(2, 0.5f, 0.01f, 1);
        eggCatcherPresenter.StartSpawner();

        //sceneRoot.OpenHeaderPanel();
    }

    public void ExitState()
    {
        scorePresenter.OnGameFailed -= ChangeStateToFail;
        scorePresenter.OnGameWinned -= ChangeStateToWin;
        eggCatcherPresenter.OnEggDown -= scorePresenter.RemoveHealth;
        eggCatcherPresenter.OnEggWin -= scorePresenter.AddScore;
        eggCatcherPresenter.OnEggDown_Position -= pointAnimationPresenter.PlayAnimation;

        eggCatcherPresenter.DeactivateSpawner();
        basketPresenter.Stop();

        //sceneRoot.CloseHeaderPanel();
        //sceneRoot.CloseFooterPanel();
    }

    private void ChangeStateToWin()
    {
        machineControl.SetState(machineControl.GetState<WinMiniGame_GlobalState>());
    }
    
    private void ChangeStateToFail()
    {
        machineControl.SetState(machineControl.GetState<FailMiniGame_GlobalState>());
    }
}
