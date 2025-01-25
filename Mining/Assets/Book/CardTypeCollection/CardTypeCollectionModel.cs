using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTypeCollectionModel
{
    public event Action<TypeCard> OnAddCard;
    public event Action<TypeCard> OnOpenDisplay;


    public void AddCardType(TypeCard typeCard)
    {
        Debug.Log(typeCard);

        OnAddCard?.Invoke(typeCard);
    }

    public void OpenDisplayType(TypeCard typeCard)
    {
        OnOpenDisplay?.Invoke(typeCard);
    }
}
