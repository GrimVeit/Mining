using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPack_MenuScene : IGlobalState
{
    private UnpackerPackPresenter unpackerPackPresenter;
    private SwipeClickAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;
    private ISoundProvider soundProvider;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        UnpackerPackPresenter unpackerPackPresenter, 
        SwipeClickAnimationPresenter swipeAnimationPresenter,
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter,
        SwipePresenter swipePresenter,
        ISoundProvider soundProvider)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipeClickDescriptionPresenter = swipeClickDescriptionPresenter;
        this.swipePresenter = swipePresenter;
        this.soundProvider = soundProvider;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN PACK STATE");

        swipePresenter.OnSwipeRight += unpackerPackPresenter.MovePackToClose_Right;
        swipePresenter.OnSwipeLeft += unpackerPackPresenter.MovePackToClose_Left;
        unpackerPackPresenter.OnStartClosePack += ChangeStateToEndOpenPack;

        swipeAnimationPresenter.ActivateAnimation("LeftRight_OpenPack");
        swipeClickDescriptionPresenter.ActivateDescription("SwipeClick_OpenPack");
        swipePresenter.Activate("OpenPackPanel");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN PACK STATE");

        unpackerPackPresenter.OnStartClosePack -= ChangeStateToEndOpenPack;

        swipeAnimationPresenter.DeactivateAnimation("LeftRight_OpenPack");
        swipeClickDescriptionPresenter.DeactivateDescription("SwipeClick_OpenPack");
        swipePresenter.Deactivate("OpenPackPanel");
    }

    private void ChangeStateToEndOpenPack()
    {
        soundProvider.PlayOneShot("OpenPack");

        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<EndOpenPack_MenuScene>());
    }
}
