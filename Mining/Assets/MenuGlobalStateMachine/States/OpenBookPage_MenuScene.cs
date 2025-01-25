using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBookPage_MenuScene : IGlobalState
{
    private BookPagesPresenter bookPagesPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public OpenBookPage_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        BookPagesPresenter bookPagesPresenter, 
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.bookPagesPresenter = bookPagesPresenter;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - OPEN BOOK PAGE STATE");

        bookPagesPresenter.OnEndOpenPage += ChangeStateToAddCard;

        bookPagesPresenter.OpenPage(addCardCollectionPresenter.CurrentAddCard.CardInfo.PageNumber);
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - OPEN BOOK PAGE STATE");

        bookPagesPresenter.OnEndOpenPage -= ChangeStateToAddCard;
    }

    private void ChangeStateToAddCard()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<AddCard_MenuScene>());
    }
}
