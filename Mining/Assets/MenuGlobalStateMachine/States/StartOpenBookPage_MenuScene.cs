using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOpenBookPage_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public StartOpenBookPage_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - START OPEN BOOK PAGE STATE");
        //Debug.Log(addCardCollectionPresenter.CurrentCardInfo.Number);
        Debug.Log(addCardCollectionPresenter.CurrentAddCard);

        if (addCardCollectionPresenter.CurrentAddCard != null)
        {
            sceneRoot.OpenCollectionPanel();
            ChangeStateToOpenBookPage();
        }
        else
        {
            ChangeStateToMain();
        }
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN BOOK PAGE STATE");
    }

    private void ChangeStateToOpenBookPage()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenBookPage_MenuScene>());
    }

    private void ChangeStateToMain()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<Main_MenuScene>());
    }
}
