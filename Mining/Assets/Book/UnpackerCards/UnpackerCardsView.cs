using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnpackerCardsView : View
{
    [SerializeField] private UnpackCard unpackCardPrefab;
    [SerializeField] private Transform transformParentSpawn;
    [SerializeField] private Transform transformSpawn;
    [SerializeField] private Transform transformLeftEnd;
    [SerializeField] private Transform transformRightEnd;

    [SerializeField] private List<UnpackCard> unpackedCards;

    private UnpackCard currentUnpackCard;

    private bool isActive;

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void SpawnNewCard(CardInfo cardInfo)
    {
        var currentCard = Instantiate(unpackCardPrefab, transformParentSpawn);
        currentCard.transform.position = transformSpawn.position;
        currentCard.transform.eulerAngles = new Vector3(0, 90, 0);
        currentCard.SetData(cardInfo, true);

        unpackedCards.Add(currentCard);
    }

    public void SpawnDuplicateCard(CardInfo cardInfo)
    {
        var currentCard = Instantiate(unpackCardPrefab, transformParentSpawn);
        currentCard.transform.position = transformSpawn.position;
        currentCard.transform.eulerAngles = new Vector3(0, 90, 0);
        currentCard.SetData(cardInfo, false);
        currentCard.ActivateDuplicate();

        unpackedCards.Add(currentCard);
    }

    public void ClearCards()
    {
        for (int i = 0; i < unpackedCards.Count; i++)
        {
            unpackedCards[i].DeatroyCard();
        }

        unpackedCards.Clear();
    }

    public void ActivateCards()
    {
        //unpackedCards.ForEach(task => task.RotateTo(Vector3.zero, 0.2f));

        RotateOpenCard();
    }

    public void MoveCardToClose_Right()
    {
        if(isActive) return;

        isActive = true;

        currentUnpackCard?.MoveTo(transformRightEnd.position, 0.4f, RotateOpenCard);
        currentUnpackCard?.RotateTo(new Vector3(0, 0, -30), 0.3f);
    }

    public void MoveCardToClose_Left()
    {

        if (isActive) return;

        isActive = true;

        currentUnpackCard?.MoveTo(transformLeftEnd.position, 0.4f, RotateOpenCard);
        currentUnpackCard?.RotateTo(new Vector3(0, 0, 30), 0.3f);
    }

    private void RotateOpenCard()
    {
        if (currentUnpackCard != null)
        {
            unpackedCards.Remove(currentUnpackCard);

            currentUnpackCard.DeatroyCard();
        }

        if(unpackedCards.Count > 0)
        {
            var index = unpackedCards.Count - 1;
            unpackedCards[index].RotateTo(Vector3.zero, 0.2f, SetNextCard);
        }
        else
        {
            Debug.Log("FINISH");
            ClearCards();
            OnAllCardsOpen?.Invoke();
        }
    }


    public void SetNextCard()
    {
        currentUnpackCard = unpackedCards[unpackedCards.Count - 1];
        OnSetNextCard?.Invoke(currentUnpackCard.CardInfo, currentUnpackCard.IsNew);
        isActive = false;
    }

    #region Input

    public event Action<CardInfo, bool> OnSetNextCard;
    public event Action OnAllCardsOpen;

    #endregion
}
