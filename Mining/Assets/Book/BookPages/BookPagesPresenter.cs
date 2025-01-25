using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPagesPresenter
{
    private BookPagesModel bookPagesModel;
    private BookPagesView bookPagesView;

    public BookPagesPresenter(BookPagesModel bookPagesModel, BookPagesView bookPagesView)
    {
        this.bookPagesModel = bookPagesModel;
        this.bookPagesView = bookPagesView;
    }

    public void Initialize()
    {
        ActivateEvents();

        bookPagesView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        bookPagesView.Dispose();
    }

    private void ActivateEvents()
    {
        bookPagesView.OnChoosePage += bookPagesModel.ChoosePage;
        bookPagesView.OnEndOpenPage += bookPagesModel.EndOpenPage;

        bookPagesModel.OnNumberPage += bookPagesView.SetDisplayNumberPage;
        bookPagesModel.OnOpenPage += bookPagesView.OpenPage;
        bookPagesModel.OnOpenSecondPage += bookPagesView.OpenSecondPage;
        bookPagesModel.OnOpenPastPage += bookPagesView.OpenPastPage;
    }

    private void DeactivateEvents()
    {
        bookPagesView.OnChoosePage -= bookPagesModel.ChoosePage;
        bookPagesView.OnEndOpenPage -= bookPagesModel.EndOpenPage;

        bookPagesModel.OnNumberPage -= bookPagesView.SetDisplayNumberPage;
        bookPagesModel.OnOpenPage -= bookPagesView.OpenPage;
        bookPagesModel.OnOpenSecondPage -= bookPagesView.OpenSecondPage;
        bookPagesModel.OnOpenPastPage -= bookPagesView.OpenPastPage;
    }

    #region Input

    public event Action<BookPage> OnNumberPage
    {
        add { bookPagesModel.OnNumberPage += value; }
        remove { bookPagesModel.OnNumberPage -= value; }
    }

    public event Action<BookPage> OnChoosePage_Second
    {
        add { bookPagesView.OnChoosePage_Second += value; }
        remove { bookPagesView.OnChoosePage_Second -= value; }
    }

    public event Action OnEndOpenPage
    {
        add { bookPagesModel.OnEndOpenPage += value; }
        remove { bookPagesModel.OnEndOpenPage -= value; }
    }

    public void OpenPage(int pageIndex)
    {
        bookPagesModel.OpenPage(pageIndex);
    }

    public void OpenSecondPage()
    {
        bookPagesModel.OpenSecondPage();
    }

    public void OpenPastPage()
    {
        bookPagesModel.OpenPastPage();
    }

    #endregion
}
