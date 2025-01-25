using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UnpackCard : MonoBehaviour
{
    public CardInfo CardInfo => cardInfo;
    public bool IsNew => isNew;

    [SerializeField] private Transform transformCard;
    [SerializeField] private Image imageCard;
    [SerializeField] private GameObject duplicateObject;

    private Tween tweenMove;
    private Tween tweenScale;
    private Tween tweenRotate;

    private CardInfo cardInfo;
    private bool isNew = false;

    public void SetData(CardInfo cardInfo, bool isNew)
    {
        imageCard.sprite = cardInfo.Sprite;
        this.cardInfo = cardInfo;
        this.isNew = isNew;
    }

    public void ActivateDuplicate()
    {
        duplicateObject.SetActive(true);
    }

    public void MoveTo(Vector3 vector, float duration, Action actionToEnd = null)
    {
        tweenMove?.Kill();

        tweenMove = transformCard.DOMove(vector, duration).OnComplete(()=> actionToEnd?.Invoke());
    }

    public void ScaleTo(Vector3 vector, float duration, Action actionToEnd = null)
    {
        tweenScale?.Kill();

        tweenScale = transformCard.DOScale(vector, duration).OnComplete(() => actionToEnd?.Invoke());
    }

    public void RotateTo(Vector3 vector, float duration, Action actionToEnd = null)
    {
        tweenRotate?.Kill();

        tweenRotate = transformCard.DORotate(vector, duration).OnComplete(() => actionToEnd?.Invoke());
    }

    public void DeatroyCard()
    {
        Destroy(gameObject);
    }
}
