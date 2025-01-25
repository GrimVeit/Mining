using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionPresenter : ICardCollection
{
    private CardCollectionModel model;
    private CardCollectionView view;

    public CardCollectionPresenter(CardCollectionModel model, CardCollectionView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        model.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnOpenCard += view.OpenCard;
    }

    private void DeactivateEvents()
    {
        model.OnOpenCard -= view.OpenCard;
    }

    #region Input

    public event Action<CardInfo> OnOpenCard
    {
        add { model.OnOpenCard += value; }
        remove { model.OnOpenCard -= value; }
    }

    public bool IsOpenCard(int id, object sender)
    {
        return model.IsOpenCard(id, sender);
    }

    public void UnlockCard(int number)
    {
        model.UnlockCard(number);
    }

    #endregion
}

public interface ICardCollection
{
    public bool IsOpenCard(int id, object s);
}
