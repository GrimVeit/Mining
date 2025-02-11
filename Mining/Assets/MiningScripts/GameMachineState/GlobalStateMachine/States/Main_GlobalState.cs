using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private PlanetInteractivePresenter planetInteractivePresenter;
    private PlanetRocketVisualPresenter planetRocketVisualPresenter;

    private IControlGlobalStateMachine controlMachine;

    public Main_GlobalState(
        IControlGlobalStateMachine controlMachine, 
        UIMiniGameSceneRoot sceneRoot,
        PlanetInteractivePresenter planetInteractivePresenter,
        PlanetRocketVisualPresenter rocketVisualPresenter)
    {
        this.controlMachine = controlMachine;
        this.sceneRoot = sceneRoot;
        this.planetInteractivePresenter = planetInteractivePresenter;
        this.planetRocketVisualPresenter = rocketVisualPresenter;
    }

    public void EnterState()
    {
        planetInteractivePresenter.OnChoosePlanet += ChangeStateToPlanetInfo;

        sceneRoot.OnClickToOpen_Map += ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription += ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale += ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop += ChangeStateToShop;

        sceneRoot.OpenGamePanel();
        sceneRoot.OpenGameplayButtonsPanel();
        planetRocketVisualPresenter.SelectDefault();
    }

    public void ExitState()
    {
        planetInteractivePresenter.OnChoosePlanet -= ChangeStateToPlanetInfo;

        sceneRoot.OnClickToOpen_Map -= ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription -= ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale -= ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop -= ChangeStateToShop;
    }

    private void ChangeStateToResourceDescription()
    {
        controlMachine.SetState(controlMachine.GetState<ResourceDescription_GlobalState>());
    }

    private void ChangeStateToResourceSale()
    {
        controlMachine.SetState(controlMachine.GetState<ResourceSale_GlobalState>());
    }

    private void ChangeStateToPlanetInfo()
    {
        controlMachine.SetState(controlMachine.GetState<PlanetInfo_GlobalState>());
    }

    private void ChangeStateToShop()
    {
        controlMachine.SetState(controlMachine.GetState<Shop_GlobalState>());
    }

    private void ChangeStateToExit()
    {
        controlMachine.SetState(controlMachine.GetState<Exit_GlobalState>());
    }
}
