using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard_MenuScene : IGlobalState
{
    private AddCardCollectionPresenter addCardCollectionPresenter;
    private CardCollectionPresenter cardCollectionPresenter;
    private SwipeClickAnimationPresenter swipeAnimationPresenter;
    private SwipePresenter swipePresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    private int indexCard;

    public AddCard_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine, 
        AddCardCollectionPresenter addCardCollectionPresenter, 
        CardCollectionPresenter cardCollectionPresenter, 
        SwipeClickAnimationPresenter swipeAnimationPresenter, 
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter,
        SwipePresenter swipePresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
        this.cardCollectionPresenter = cardCollectionPresenter;
        this.swipeAnimationPresenter = swipeAnimationPresenter;
        this.swipeClickDescriptionPresenter = swipeClickDescriptionPresenter;
        this.swipePresenter = swipePresenter;
    }

    public void EnterState()
    {
        swipePresenter.OnSwipeDown += addCardCollectionPresenter.MoveCurrentCard;
        addCardCollectionPresenter.OnEndMove_Value += OnEndMove;
        addCardCollectionPresenter.OnEndMove += ChangeStateToOpenPageBook;

        addCardCollectionPresenter.ActivateCurrentCard();
        swipePresenter.Activate("CollectionPanel");
        swipeClickDescriptionPresenter.ActivateDescription("SwipeClick_CollectionDescription");

        ActivateSwipeAnimation();
    }

    private void ActivateSwipeAnimation()
    {
        indexCard = (addCardCollectionPresenter.CurrentAddCard.CardInfo.Number + 1) % 9;

        Debug.Log($"SWIPE_CARD_{indexCard}");

        if(indexCard == 0)
        {
            swipeAnimationPresenter.ActivateAnimation("UpToDownCard_9");
        }
        else
        {
            swipeAnimationPresenter.ActivateAnimation($"UpToDownCard_{indexCard}");
        }

    }

    private void DeactivateSwipeAnimation()
    {
        swipePresenter.OnSwipeDown -= addCardCollectionPresenter.MoveCurrentCard;

        if (indexCard == 0)
        {
            swipeAnimationPresenter.DeactivateAnimation("UpToDownCard_9");
        }
        else
        {
            swipeAnimationPresenter.DeactivateAnimation($"UpToDownCard_{indexCard}");
        }
    }

    public void ExitState()
    {
        addCardCollectionPresenter.OnEndMove_Value -= OnEndMove;
        addCardCollectionPresenter.OnEndMove -= ChangeStateToOpenPageBook;
        swipePresenter.Deactivate("CollectionPanel");
        swipeClickDescriptionPresenter.DeactivateDescription("SwipeClick_CollectionDescription");

        DeactivateSwipeAnimation();
    }

    private void OnEndMove(CardInfo cardInfo)
    {
        cardCollectionPresenter.UnlockCard(cardInfo.Number);
    }

    private void ChangeStateToOpenPageBook()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<StartOpenBookPage_MenuScene>());
    }
}
