using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private ShopPackPresenter shopPackPresenter;
    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;


    private IControlGlobalStateMachine globalMachineControl;

    public Main_MenuScene(
        IControlGlobalStateMachine globalMachineControl, 
        UIMainMenuRoot sceneRoot, 
        ShopPackPresenter shopPackPresenter,
        UnpackerPackPresenter unpackerPackPresenter,
        UnpackerCardsPresenter unpackerCardsPresenter,
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.globalMachineControl = globalMachineControl;
        this.sceneRoot = sceneRoot;
        this.shopPackPresenter = shopPackPresenter;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - MAIN STATE");

        ActivateTransitions();

        shopPackPresenter.OnBuyRandomSpin += ChangeStateToStartPackSpin;

        sceneRoot.OpenShopPanel();
    }

    private void ActivateTransitions()
    {
        sceneRoot.OnClickCollectionsButton += ChangeStateToReadBook;
        sceneRoot.OnClickBackButtonFromShopPanel += ChangeStateToHello;
    }

    private void DeactivateTransitions()
    {
        sceneRoot.OnClickCollectionsButton -= ChangeStateToReadBook;
        sceneRoot.OnClickBackButtonFromShopPanel -= ChangeStateToHello;
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - MAIN STATE");

        DeactivateTransitions();

        shopPackPresenter.OnBuyRandomSpin -= ChangeStateToStartPackSpin;
    }

    private void ChangeStateToHello()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<Hello_MenuScene>());
    }

    private void ChangeStateToStartPackSpin()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<PackSpin_MenuScene>());
    }

    private void ChangeStateToReadBook()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<ReadBookPage_MenuScene>());
    }
}
