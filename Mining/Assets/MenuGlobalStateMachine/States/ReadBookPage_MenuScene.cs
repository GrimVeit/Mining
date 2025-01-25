using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBookPage_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private BookPagesPresenter bookPagesPresenter;
    private SwipeClickAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public ReadBookPage_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UIMainMenuRoot sceneRoot,
        BookPagesPresenter bookPagesPresenter,
        SwipeClickAnimationPresenter swipeAnimationPresenter,
        SwipePresenter swipePresenter,
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.sceneRoot = sceneRoot;
        this.bookPagesPresenter = bookPagesPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipePresenter = swipePresenter;
        this.swipeClickDescriptionPresenter = swipeClickDescriptionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - READ BOOK STATE");

        //sceneRoot.OnClickBackButtonFromCollectionPanel += ChangeStateToMain;
        swipePresenter.OnSwipeRight += bookPagesPresenter.OpenPastPage;
        swipePresenter.OnSwipeLeft += bookPagesPresenter.OpenSecondPage;

        //sceneRoot.OpenCollectionPanel();
        //sceneRoot.OpenCollectionHeaderPanel();
        swipePresenter.Activate("CollectionPanel");
        swipeAnimationPresenter.ActivateAnimation("LeftRight_ReadBook");
        //swipeClickDescriptionPresenter.ActivateDescription("SwipeClick_Description");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - READ BOOK STATE");

        //sceneRoot.OnClickBackButtonFromCollectionPanel -= ChangeStateToMain;
        swipePresenter.OnSwipeRight -= bookPagesPresenter.OpenPastPage;
        swipePresenter.OnSwipeLeft -= bookPagesPresenter.OpenSecondPage;

        //sceneRoot.CloseCollectionHeaderPanel();
        swipePresenter.Deactivate("CollectionPanel");
        swipeAnimationPresenter.DeactivateAnimation("LeftRight_ReadBook");
        //swipeClickDescriptionPresenter.DeactivateDescription("SwipeClick_Description");
    }

    private void ChangeStateToMain()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<Main_MenuScene>());
    }
}
