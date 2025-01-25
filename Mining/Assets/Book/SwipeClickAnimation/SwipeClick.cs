using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwipeClick : MonoBehaviour
{
    [SerializeField] private Transform transformSwipe;

    private Tween tweenMove;
    private Tween tweenScale;

    public void MoveTo(Vector2 vector, float duration, Ease ease, Action actionToEnd = null)
    {
        tweenMove?.Kill();

        tweenMove = transformSwipe.DOMove(vector, duration).OnComplete(()=> actionToEnd?.Invoke()).SetEase(ease);
    }

    public void ScaleTo(Vector2 vector, float duration, Action actionToEnd = null)
    {
        tweenScale?.Kill();

        tweenScale = transformSwipe.DOScale(vector, duration).OnComplete(()=> actionToEnd?.Invoke());
    }

    public void SetScale(Vector3 vector)
    {
        transformSwipe.localScale = vector;
    }

    public void KillAllTweens()
    {
        tweenScale?.Kill();
        tweenMove?.Kill();
    }

    public void DestroyScale()
    {
        ScaleTo(Vector2.zero, 0.3f, DestroySwipe);
    }

    private void DestroySwipe()
    {
        KillAllTweens();

        Destroy(transformSwipe.gameObject);
    }
}
