using System;
using System.Collections.Generic;

public class MiniGameGlobalStateMachine : IControlGlobalStateMachine
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentGlobalState;

    public MiniGameGlobalStateMachine(
        UIMiniGameSceneRoot sceneRoot,
        PlanetInteractivePresenter planetInteractivePresenter,
        PlanetRocketVisualPresenter planetRocketVisualPresenter,
        ShipInfoPresenter shipInfoPresenter)
    {
        states[typeof(StartGame_GlobalState)] = new StartGame_GlobalState(this, sceneRoot, shipInfoPresenter);
        states[typeof(Main_GlobalState)] = new Main_GlobalState(this, sceneRoot, planetInteractivePresenter, planetRocketVisualPresenter);
        states[typeof(PlanetInfo_GlobalState)] = new PlanetInfo_GlobalState(this, sceneRoot, planetInteractivePresenter);
        states[typeof(ResourceDescription_GlobalState)] = new ResourceDescription_GlobalState(this, sceneRoot, planetInteractivePresenter, planetRocketVisualPresenter);
        states[typeof(ResourceSale_GlobalState)] = new ResourceSale_GlobalState(this, sceneRoot, planetInteractivePresenter, planetRocketVisualPresenter);
        states[typeof(Shop_GlobalState)] = new Shop_GlobalState(this, sceneRoot, planetInteractivePresenter);
        states[typeof(Exit_GlobalState)] = new Exit_GlobalState(this, sceneRoot, planetRocketVisualPresenter);
    }

    public void Initialize()
    {
        SetState(GetState<StartGame_GlobalState>());
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
