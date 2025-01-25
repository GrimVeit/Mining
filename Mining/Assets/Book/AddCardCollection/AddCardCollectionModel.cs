using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardCollectionModel
{
    public event Action OnMoveCurrentCard;
    public event Action<CardInfo> OnAddNewCard;

    private ISoundProvider soundProvider;
    public AddCardCollectionModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void AddCard(CardInfo cardInfo)
    {
        OnAddNewCard?.Invoke(cardInfo);
    }

    public void MoveCurrentCard()
    {
        soundProvider.PlayOneShot("MoveCardToBox");

        OnMoveCurrentCard?.Invoke();
    }
}
