using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSale_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private PlanetInteractivePresenter planetInteractivePresenter;
    private PlanetRocketVisualPresenter planetRocketVisualPresenter;

    private IControlGlobalStateMachine controlMachine;

    public ResourceSale_GlobalState(
        IControlGlobalStateMachine controlMachine, 
        UIMiniGameSceneRoot sceneRoot,
        PlanetInteractivePresenter planetInteractivePresenter,
        PlanetRocketVisualPresenter planetRocketVisualPresenter)
    {
        this.controlMachine = controlMachine;
        this.sceneRoot = sceneRoot;
        this.planetInteractivePresenter = planetInteractivePresenter;
        this.planetRocketVisualPresenter = planetRocketVisualPresenter;
    }

    public void EnterState()
    {
        planetInteractivePresenter.OnChoosePlanet += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToClose_ResourceSale += ChangeStateToMain;

        sceneRoot.OnClickToOpen_Map += ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription += ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale += ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop += ChangeStateToShop;

        sceneRoot.OpenResourceSalePanel();

        planetRocketVisualPresenter.SelectShip();
    }

    public void ExitState()
    {
        planetInteractivePresenter.OnChoosePlanet -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToClose_ResourceSale -= ChangeStateToMain;

        sceneRoot.OnClickToOpen_Map -= ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription -= ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale -= ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop -= ChangeStateToShop;
    }

    private void ChangeStateToMain()
    {
        sceneRoot.CloseResourceSalePanel();

        controlMachine.SetState(controlMachine.GetState<Main_GlobalState>());
    }

    private void ChangeStateToResourceDescription()
    {
        sceneRoot.CloseResourceSalePanel();

        controlMachine.SetState(controlMachine.GetState<ResourceDescription_GlobalState>());
    }

    private void ChangeStateToResourceSale()
    {
        controlMachine.SetState(controlMachine.GetState<ResourceSale_GlobalState>());
    }

    private void ChangeStateToPlanetInfo()
    {
        sceneRoot.CloseResourceSalePanel();

        controlMachine.SetState(controlMachine.GetState<PlanetInfo_GlobalState>());
    }

    private void ChangeStateToShop()
    {
        sceneRoot.CloseResourceSalePanel();

        controlMachine.SetState(controlMachine.GetState<Shop_GlobalState>());
    }

    private void ChangeStateToExit()
    {
        sceneRoot.CloseResourceSalePanel();

        controlMachine.SetState(controlMachine.GetState<Exit_GlobalState>());
    }
}
