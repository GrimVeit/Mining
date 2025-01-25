using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CardTypeCollection : MonoBehaviour
{
    public TypeCard TypeCards => typeCards;

    [SerializeField] private TypeCard typeCards;
    [SerializeField] private int maxCountCards;
    [SerializeField] private Transform transformDisplay;
    [SerializeField] private TextMeshProUGUI textCount;

    private Tween tweenScale;

    private int currentCardCount = 0;

    public void Activate()
    {
        tweenScale?.Kill();

        transformDisplay.gameObject.SetActive(true);
        tweenScale = transformDisplay.DOScale(Vector3.one, 0.2f);
    }

    public void Deactivate()
    {
        tweenScale?.Kill();

        tweenScale = transformDisplay.DOScale(Vector3.zero, 0.2f).OnComplete(()=> { transformDisplay.gameObject.SetActive(false); });
    }


    public void AddCard()
    {
        currentCardCount += 1;

        textCount.text = $"{currentCardCount}/{maxCountCards}";
    }
}
