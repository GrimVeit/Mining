using System;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerCardsModel
{
    public event Action OnMoveCardToClose_Left;
    public event Action OnMoveCardToClose_Right;

    public event Action OnActivatedCards;

    public event Action<CardInfo> OnSpawnDuplicateCard;
    public event Action<CardInfo> OnSpawnNewCard;

    private Cards cards;

    private ICardCollection cardCollection;

    private List<CardInfo> newCardList = new List<CardInfo>();

    private ISoundProvider soundProvider;
    private IParticleEffectProvider particleEffectProvider;

    public UnpackerCardsModel(Cards cards, ICardCollection cardCollection, ISoundProvider soundProvider, IParticleEffectProvider particleEffectProvider)
    {
        this.cards = cards;
        this.cardCollection = cardCollection;
        this.soundProvider = soundProvider;
        this.particleEffectProvider = particleEffectProvider;
    }

    public void SpawnCards(Pack pack)
    {
        newCardList.Clear();

        for (int i = 0; i < pack.Items.Count; i++)
        {
            GetRandom(pack.Items[i]);
        }
    }

    private void GetRandom(TypeCard typeCard)
    {
        var cardInfo = cards.GetRandomCardInfo(typeCard);

        //Debug.Log(cardCollection);

        if (cardCollection.IsOpenCard(cardInfo.Number, this))
        {
            OnSpawnDuplicateCard?.Invoke(cardInfo);
        }
        else
        {
            if (IsAlreadyOpen(cardInfo))
            {
                OnSpawnDuplicateCard?.Invoke(cardInfo);
            }
            else
            {
                OnSpawnNewCard?.Invoke(cardInfo);
                newCardList.Add(cardInfo);
            }
        }
    }

    private bool IsAlreadyOpen(CardInfo cardInfo)
    {
        return newCardList.Contains(cardInfo);
    }

    public void ActivateCards()
    {
        OnActivatedCards?.Invoke();
    }

    public void MoveCardToClose_Right()
    {
        soundProvider.PlayOneShot("MoveCard_Right");

        OnMoveCardToClose_Right?.Invoke();
    }

    public void MoveCardToClose_Left()
    {
        OnMoveCardToClose_Left?.Invoke();

        soundProvider.PlayOneShot("MoveCard_Left");
    }

    public void OnSetCard(CardInfo cardInfo, bool isNew)
    {
        Debug.LogWarning(cardInfo.cardType + "//" + cardInfo.Number + "//" + isNew);

        if (isNew)
        {
            switch (cardInfo.cardType)
            {
                case TypeCard.common:
                    soundProvider.PlayOneShot("NewCard_Common");
                    particleEffectProvider.Play("NewCard_Common");
                    break;
                case TypeCard.rare:
                    soundProvider.PlayOneShot("NewCard_Rare");
                    particleEffectProvider.Play("NewCard_Rare");
                    break;
                case TypeCard.epic:
                    soundProvider.PlayOneShot("NewCard_Epic");
                    particleEffectProvider.Play("NewCard_Epic");
                    break;
                case TypeCard.legendary:
                    soundProvider.PlayOneShot("NewCard_Legendary");
                    particleEffectProvider.Play("NewCard_Legendary");
                    break;
                case TypeCard.gold:
                    soundProvider.PlayOneShot("NewCard_Gold");
                    particleEffectProvider.Play("NewCard_Gold");
                    break;
            }
        }
        else
        {
            soundProvider.PlayOneShot("DuplicateCard");
        }
    }
}
