using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameGlobalStateMachine : IControlGlobalStateMachine
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentGlobalState;

    public MiniGameGlobalStateMachine(
        UIMiniGameSceneRoot sceneRoot, 
        BasketPresenter basketPresenter, 
        EggCatcherPresenter eggCatcherPresenter, 
        ScorePresenter scorePresenter,
        PointAnimationPresenter pointAnimationPresenter,
        TimerPresenter timerPresenter,
        ISoundProvider soundProvider,
        IParticleEffectProvider particleEffectProvider)
    {
        states[typeof(StartMiniGame_GlobalState)] = new StartMiniGame_GlobalState(this, sceneRoot, basketPresenter, timerPresenter);
        states[typeof(MiniGame_GlobalState)] = new MiniGame_GlobalState(this, sceneRoot, basketPresenter, eggCatcherPresenter, scorePresenter, pointAnimationPresenter);
        states[typeof(WinMiniGame_GlobalState)] = new WinMiniGame_GlobalState(this, sceneRoot, eggCatcherPresenter, pointAnimationPresenter, soundProvider, particleEffectProvider);
        states[typeof(FailMiniGame_GlobalState)] = new FailMiniGame_GlobalState(this, sceneRoot, eggCatcherPresenter, pointAnimationPresenter, soundProvider);
    }

    public void Initialize()
    {
        SetState(GetState<StartMiniGame_GlobalState>());
    }

    public void Dispose()
    {

    }

    public IGlobalState GetState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }

    public void SetState(IGlobalState state)
    {
        currentGlobalState?.ExitState();

        currentGlobalState = state;
        currentGlobalState.EnterState();
    }
}

public interface IControlGlobalStateMachine
{
    public IGlobalState GetState<T>() where T : IGlobalState;

    public void SetState(IGlobalState state);
}
