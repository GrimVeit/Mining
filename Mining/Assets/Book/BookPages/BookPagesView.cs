using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookPagesView : View
{
    [SerializeField] private int index;

    [SerializeField] private List<BookPage> openPages = new List<BookPage>();
    [SerializeField] private Transform parentClosePages;
    [SerializeField] private Transform parentOpenPages;

    [SerializeField] private BookPage currentOpenPage;

    [SerializeField] private TextMeshProUGUI textPage;

    private IEnumerator enumerator;

    public void Initialize()
    {

        currentOpenPage = openPages[0];
        currentOpenPage.ClosePage();
        currentOpenPage.transform.SetParent(parentClosePages);

        //OnChoosePage?.Invoke(currentOpenPage);
        OnChoosePage_Second?.Invoke(openPages.FirstOrDefault(data => data.BookPageData.Index == currentOpenPage.BookPageData.Index + 1));
    }

    public void Dispose()
    {

    }

    private IEnumerator OpenPage_Coroutine(int index)
    {
        int currentIndex = currentOpenPage.BookPageData.Index;

        if(currentIndex < index)
        {
            for(int i = currentIndex;  i <= index; i++)
            {
                currentOpenPage = openPages[i];
                currentOpenPage.ClosePage();
                currentOpenPage.transform.SetParent(parentClosePages);

                OnChoosePage?.Invoke(currentOpenPage);
                OnChoosePage_Second?.Invoke(openPages.FirstOrDefault(data => data.BookPageData.Index == currentOpenPage.BookPageData.Index + 1));

                yield return new WaitForSeconds(0.1f);
            }

            OnEndOpenPage?.Invoke();
            Debug.Log(currentOpenPage.BookPageData.Index);
            yield break;
        }
        else if(currentIndex > index)
        {
            for (int i = currentIndex; i >= index; i--)
            {
                currentOpenPage = openPages[i];

                if (i != index)
                {
                    currentOpenPage.OpenPage();
                    currentOpenPage.transform.SetParent(parentOpenPages);
                }

                OnChoosePage?.Invoke(currentOpenPage);
                OnChoosePage_Second?.Invoke(openPages.FirstOrDefault(data => data.BookPageData.Index == currentOpenPage.BookPageData.Index + 1));

                yield return new WaitForSeconds(0.1f);
            }

            OnEndOpenPage?.Invoke();
            Debug.Log(currentOpenPage.BookPageData.Index);
            yield break;
        }

        OnEndOpenPage?.Invoke();
        OnChoosePage_Second?.Invoke(openPages.FirstOrDefault(data => data.BookPageData.Index == currentOpenPage.BookPageData.Index + 1));
    }

    public void OpenPage(int page)
    {
        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(page);
        Coroutines.Start(enumerator);
    }

    public void OpenSecondPage()
    {
        int index = currentOpenPage.BookPageData.Index + 1;
        if(index > openPages[openPages.Count - 2].BookPageData.Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(index);
        Coroutines.Start(enumerator);
    }

    public void OpenPastPage()
    {
        int index = currentOpenPage.BookPageData.Index - 1;
        if (index < openPages[0].BookPageData.Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(index);
        Coroutines.Start(enumerator);
    }


    public void SetDisplayNumberPage(BookPage bookPage)
    {
        textPage.text = $"Page: {bookPage.BookPageData.Index + 1}";
    }

    #region Input

    public event Action<BookPage> OnChoosePage;
    public event Action<BookPage> OnChoosePage_Second;

    public event Action OnEndOpenPage;

    #endregion
}
