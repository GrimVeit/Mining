using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UnpackPack : MonoBehaviour
{
    [SerializeField] private Transform transformPack;
    [SerializeField] private Image imagePack;

    private Tween tweenMove;
    private Tween tweenScale;
    private Tween tweenRotate;

    public void SetData(Sprite sprite)
    {
        imagePack.sprite = sprite;
    }

    public void MoveTo(Vector3 vector, float duration, Action actionToFinish = null)
    {
        tweenMove?.Kill();

        tweenMove = transformPack.DOMove(vector, duration).OnComplete(() => actionToFinish?.Invoke());
    }

    public void ScaleTo(Vector3 vector, float duration, Action actionToFinish = null)
    {
        tweenScale?.Kill();

        tweenScale = transformPack.DOScale(vector, duration).OnComplete(()=> actionToFinish?.Invoke());
    }

    public void RotateTo(Vector3 vector, float duration, Action actionToFinish = null)
    {
        tweenRotate?.Kill();

        tweenRotate = transformPack.DORotate(vector, duration).OnComplete(() => actionToFinish?.Invoke());
    }

    public void DestroyPack()
    {
        Destroy(gameObject);
    }
}
