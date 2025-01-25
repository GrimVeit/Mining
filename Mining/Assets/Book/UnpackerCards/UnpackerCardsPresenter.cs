using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerCardsPresenter
{
    private UnpackerCardsModel model;
    private UnpackerCardsView view;

    public UnpackerCardsPresenter(UnpackerCardsModel model, UnpackerCardsView view)
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
        view.OnSetNextCard += model.OnSetCard;

        model.OnActivatedCards += view.ActivateCards;
        model.OnSpawnNewCard += view.SpawnNewCard;
        model.OnSpawnDuplicateCard += view.SpawnDuplicateCard;

        model.OnMoveCardToClose_Left += view.MoveCardToClose_Left;
        model.OnMoveCardToClose_Right += view.MoveCardToClose_Right;
    }

    private void DeactivateEvents()
    {
        view.OnSetNextCard -= model.OnSetCard;

        model.OnActivatedCards -= view.ActivateCards;
        model.OnSpawnNewCard -= view.SpawnNewCard;
        model.OnSpawnDuplicateCard -= view.SpawnDuplicateCard;

        model.OnMoveCardToClose_Left -= view.MoveCardToClose_Left;
        model.OnMoveCardToClose_Right -= view.MoveCardToClose_Right;
    }

    #region Input

    public event Action<CardInfo> OnSpawnNewCard
    {
        add { model.OnSpawnNewCard += value; }
        remove { model.OnSpawnNewCard -= value; }
    }

    public event Action OnAllCardsOpen
    {
        add { view.OnAllCardsOpen += value; }
        remove { view.OnAllCardsOpen -= value; }
    }

    public void SpawnCards(Pack pack)
    {
        model.SpawnCards(pack);
    }

    public void ActivateCards()
    {
        model.ActivateCards();
    }

    public void MoveCardToClose_Right()
    {
        model.MoveCardToClose_Right();
    }

    public void MoveCardToClose_Left()
    {
        model.MoveCardToClose_Left();
    }

    #endregion
}
