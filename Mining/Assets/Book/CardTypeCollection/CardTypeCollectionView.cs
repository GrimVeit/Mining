using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardTypeCollectionView : View
{
    [SerializeField] private List<CardTypeCollection> cardTypeCollections = new List<CardTypeCollection>();

    private CardTypeCollection currentCardTypeCollection;

    public void Activate(TypeCard typeCard)
    {
        if(currentCardTypeCollection == null)
        {
            currentCardTypeCollection = cardTypeCollections.FirstOrDefault(data => data.TypeCards == typeCard);
            currentCardTypeCollection.Activate();
        }

        if (currentCardTypeCollection.TypeCards == typeCard) return;

        currentCardTypeCollection?.Deactivate();

        currentCardTypeCollection = cardTypeCollections.FirstOrDefault(data => data.TypeCards == typeCard);
        currentCardTypeCollection.Activate();
    }

    public void AddCard(TypeCard typeCard)
    {
        cardTypeCollections.FirstOrDefault(data => data.TypeCards == typeCard).AddCard();
    }
}
