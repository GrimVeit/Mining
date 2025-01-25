using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardCollectionPresenter
{
    private AddCardCollectionModel model;
    private AddCardCollectionView view;

    public AddCardCollectionPresenter(AddCardCollectionModel model, AddCardCollectionView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnAddNewCard += view.AddNewCard;
        model.OnMoveCurrentCard += view.MoveCard;
    }

    private void DeactivateEvents()
    {
        model.OnAddNewCard -= view.AddNewCard;
        model.OnMoveCurrentCard -= view.MoveCard;
    }

    #region Input

    public event Action<CardInfo> OnEndMove_Value
    {
        add { view.OnMoveCardEnd_Value += value; }
        remove { view.OnMoveCardEnd_Value -= value; }
    }

    public event Action OnEndMove
    {
        add { view.OnMoveCardEnd += value; }
        remove { view.OnMoveCardEnd -= value; }
    }

    public AddCard CurrentAddCard => view.CurrentAddCard;

    public void AddCard(CardInfo cardInfo)
    {
        model.AddCard(cardInfo);
    }

    public void ActivateCurrentCard()
    {
        view.ActivateCurrentCard();
    }

    public void MoveCurrentCard()
    {
        model.MoveCurrentCard();
    }

    #endregion
}
