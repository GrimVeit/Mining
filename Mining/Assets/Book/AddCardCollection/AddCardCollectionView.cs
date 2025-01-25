using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardCollectionView : View
{
    public AddCard CurrentAddCard => currentAddCard;

    [SerializeField] private List<AddCard> allAddCards = new List<AddCard>();
    [SerializeField] private Card cardPrefab;

    [SerializeField] private List<AddCard> usedAddCards = new List<AddCard>();

    private AddCard currentAddCard = null;

    private bool isActive = false;

    public void Initialize()
    {
        for (int i = 0; i < allAddCards.Count; i++)
        {
            allAddCards[i].OnEndMove += OnEndMoveCard;
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < allAddCards.Count; i++)
        {
            allAddCards[i].OnEndMove -= OnEndMoveCard;
        }
    }

    public void AddNewCard(CardInfo cardInfo)
    {
        Debug.Log(cardInfo.Number);

        var card = allAddCards[cardInfo.Number];
        card.SetData(cardPrefab, cardInfo);
        usedAddCards.Add(card);

        currentAddCard = usedAddCards[0];
    }

    public void ActivateCurrentCard()
    {
        currentAddCard.ActivateCard();
    }

    public void MoveCard()
    {
        if (isActive) return;

        isActive = true;

        currentAddCard.MoveCard();
    }

    public void OnEndMoveCard(CardInfo cardInfo)
    {
        OnMoveCardEnd_Value?.Invoke(cardInfo);

        SetNextAddCard();
        OnMoveCardEnd?.Invoke();

    }

    private void SetNextAddCard()
    {
        usedAddCards.Remove(currentAddCard);
        currentAddCard.DestroyCard();

        if(usedAddCards.Count > 0)
        {
            currentAddCard = usedAddCards[0];
        }
        else
        {
            currentAddCard = null;

            OnFinish?.Invoke();
        }

        isActive = false;
    }

    #region Input

    public event Action OnFinish;

    public event Action<CardInfo> OnMoveCardEnd_Value;
    public event Action OnMoveCardEnd;

    #endregion
}
