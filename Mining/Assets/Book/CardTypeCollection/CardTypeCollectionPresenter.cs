using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTypeCollectionPresenter
{
    private CardTypeCollectionModel typeCollectionModel;
    private CardTypeCollectionView typeCollectionView;

    public CardTypeCollectionPresenter(CardTypeCollectionModel typeCollectionModel, CardTypeCollectionView typeCollectionView)
    {
        this.typeCollectionModel = typeCollectionModel;
        this.typeCollectionView = typeCollectionView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        typeCollectionModel.OnOpenDisplay += typeCollectionView.Activate;
        typeCollectionModel.OnAddCard += typeCollectionView.AddCard;
    }

    private void DeactivateEvents()
    {
        typeCollectionModel.OnOpenDisplay -= typeCollectionView.Activate;
        typeCollectionModel.OnAddCard -= typeCollectionView.AddCard;
    }

    #region Input

    public void AddCardType(CardInfo cardInfo)
    {
        typeCollectionModel.AddCardType(cardInfo.cardType);
    }

    public void OpenDisplay(BookPage bookPage)
    {
        typeCollectionModel.OpenDisplayType(bookPage.BookPageData.TypeCards);
    }

    #endregion
}
