using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPagesModel
{
    public event Action OnEndOpenPage;

    public event Action OnOpenSecondPage;
    public event Action OnOpenPastPage;
    public event Action<int> OnOpenPage;

    public event Action<BookPage> OnNumberPage;

    private ISoundProvider soundProvider;

    public BookPagesModel(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void OpenPage(int page)
    {
        OnOpenPage?.Invoke(page);
    }

    public void OpenSecondPage()
    {
        OnOpenSecondPage?.Invoke();
    }

    public void OpenPastPage()
    {
        OnOpenPastPage?.Invoke();
    }

    public void ChoosePage(BookPage bookPage)
    {
        soundProvider.Play("SelectList");

        OnNumberPage?.Invoke(bookPage);
    }

    public void EndOpenPage()
    {
        OnEndOpenPage?.Invoke();
    }
}
