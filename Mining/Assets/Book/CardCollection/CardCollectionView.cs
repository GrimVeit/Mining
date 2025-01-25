using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollectionView : View
{
    [SerializeField] private List<Transform> cardsTransforms = new List<Transform>();
    [SerializeField] private Card cardPrefab;

    [SerializeField] private List<Card> spawnedCards = new List<Card>();

    public void OpenCard(CardInfo cardInfo)
    {
        var card = Instantiate(cardPrefab, cardsTransforms[cardInfo.Number]);
        card.transform.SetLocalPositionAndRotation(Vector3.zero, cardPrefab.transform.rotation);
        card.SetData(cardInfo.Sprite);

        spawnedCards.Add(card);
    }
}
