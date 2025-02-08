using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private PlanetInteractivePresenter planetInteractivePresenter;

    private IControlGlobalStateMachine controlMachine;

    public Shop_GlobalState(
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
        sceneRoot.OnClickToClose_Shop += ChangeStateToMain;

        sceneRoot.OnClickToOpen_Map += ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription += ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale += ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo += ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop += ChangeStateToShop;

        sceneRoot.OpenShopPanel();
    }

    public void ExitState()
    {
        planetInteractivePresenter.OnChoosePlanet -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToClose_Shop -= ChangeStateToMain;

        sceneRoot.OnClickToOpen_Map -= ChangeStateToExit;
        sceneRoot.OnClickToOpen_ResourceDescription -= ChangeStateToResourceDescription;
        sceneRoot.OnClickToOpen_ResourceSale -= ChangeStateToResourceSale;
        sceneRoot.OnClickToOpen_PlanetInfo -= ChangeStateToPlanetInfo;
        sceneRoot.OnClickToOpen_Shop -= ChangeStateToShop;
    }

    private void ChangeStateToMain()
    {
        sceneRoot.CloseShopPanel();

        controlMachine.SetState(controlMachine.GetState<Main_GlobalState>());
    }

    private void ChangeStateToResourceDescription()
    {
        sceneRoot.CloseShopPanel();

        controlMachine.SetState(controlMachine.GetState<ResourceDescription_GlobalState>());
    }

    private void ChangeStateToResourceSale()
    {
        sceneRoot.CloseShopPanel();

        controlMachine.SetState(controlMachine.GetState<ResourceSale_GlobalState>());
    }

    private void ChangeStateToPlanetInfo()
    {
        sceneRoot.CloseShopPanel();

        controlMachine.SetState(controlMachine.GetState<PlanetInfo_GlobalState>());
    }

    private void ChangeStateToShop()
    {
        controlMachine.SetState(controlMachine.GetState<Shop_GlobalState>());
    }

    private void ChangeStateToExit()
    {
        sceneRoot.CloseShopPanel();

        controlMachine.SetState(controlMachine.GetState<Exit_GlobalState>());
    }
}
