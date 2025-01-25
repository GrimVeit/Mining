using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOpenCards_MenuScene : IGlobalState
{
    private ClickPresenter clickPresenter;
    private SwipeClickAnimationPresenter swipeClickAnimationPresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public EndOpenCards_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        SwipeClickAnimationPresenter swipeClickAnimationPresenter,
        ClickPresenter clickPresenter,
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.swipeClickAnimationPresenter = swipeClickAnimationPresenter;
        this.clickPresenter = clickPresenter;
        this.swipeClickDescriptionPresenter = swipeClickDescriptionPresenter;
    }


    public void EnterState()
    {
        Debug.Log("Activate - END PACK SPIN STATE");

        clickPresenter.OnClick += ChangeStateToOpenPageBook;

        swipeClickAnimationPresenter.ActivateAnimation("Click_OpenCollection");
        swipeClickDescriptionPresenter.ActivateDescription("SwipeClick_EndOpenCards");
        clickPresenter.Activate("Click_CollectionZone");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - END PACK SPIN STATE");

        clickPresenter.OnClick -= ChangeStateToOpenPageBook;

        swipeClickAnimationPresenter.DeactivateAnimation("Click_OpenCollection");
        swipeClickDescriptionPresenter.DeactivateDescription("SwipeClick_EndOpenCards");
        clickPresenter.Deactivate("Click_CollectionZone");
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<StartOpenBookPage_MenuScene>());
    }
}
