using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private PlanetInteractivePresenter planetInteractivePresenter;

    private IControlGlobalStateMachine controlMachine;

    public PlanetInfo_GlobalState(
        IControlGlobalStateMachine controlMachine, 
        UIMiniGameSceneRoot sceneRoot,
        PlanetInteractivePresenter planetInteractivePresenter)
    {
        this.controlMachine = controlMachine;
        this.sceneRoot = sceneRoot;
        this.planetInteractivePresenter = planetInteractivePresenter;
    }

    public void EnterState()
    {
        planetInteractivePresenter.OnChoosePlanet += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToClose_InfoPlanet += ChangeStateToMain;

        sceneRoot.OnClickToOpen_ResourceDescription += ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale += ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop += ChangeStateToShop;

        sceneRoot.OpenPlanetInfoPanel();
    }

    public void ExitState()
    {
        planetInteractivePresenter.OnChoosePlanet -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToClose_InfoPlanet -= ChangeStateToMain;

        sceneRoot.OnClickToOpen_ResourceDescription -= ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale -= ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop += ChangeStateToShop;
    }

    private void ChangeStateToMain()
    {
        sceneRoot.ClosePlanetInfoPanel();
        controlMachine.SetState(controlMachine.GetState<Main_GlobalState>());
    }

    private void ChangeStateToResourceDescription()
    {
        sceneRoot.ClosePlanetInfoPanel();
        controlMachine.SetState(controlMachine.GetState<ResourceDescription_GlobalState>());
    }

    private void ChangeStateToResourceSale()
    {
        sceneRoot.ClosePlanetInfoPanel();
        controlMachine.SetState(controlMachine.GetState<ResourceSale_GlobalState>());
    }

    private void ChangeStateToPlanetInfo()
    {
        controlMachine.SetState(controlMachine.GetState<PlanetInfo_GlobalState>());
    }

    private void ChangeStateToShop()
    {
        sceneRoot.ClosePlanetInfoPanel();
        controlMachine.SetState(controlMachine.GetState<Shop_GlobalState>());
    }
}
