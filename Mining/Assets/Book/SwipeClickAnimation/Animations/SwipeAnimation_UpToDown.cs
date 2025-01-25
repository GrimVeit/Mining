using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwipeAnimation_UpToDown : SwipeClickAnimation
{
    public override string GetID() => id;

    [SerializeField] private string id;

    [SerializeField] private Transform parent;
    [SerializeField] private Transform transformUp;
    [SerializeField] private Transform transformDown;

    private SwipeClick swipePrefab;

    private SwipeClick currentSwipe;

    public override void SetSwipe(SwipeClick swipe)
    {
        swipePrefab = swipe;
    }

    public override void ActivateAnimation()
    {
        currentSwipe = Instantiate(swipePrefab, parent);
        currentSwipe.SetScale(Vector2.zero);
        ScaleToMax();
    }

    private void ScaleToMax()
    {
        currentSwipe.transform.position = transformUp.position;
        ScaleMax(MoveToDown);
    }


    private void MoveToDown()
    {
        currentSwipe.MoveTo(transformDown.position, 1f, Ease.InOutCubic, ScaleToMin);
    }

    private void ScaleToMin()
    {
        ScaleMin(ScaleToMax);
    }

    private void ScaleMin(Action actionToEnd = null)
    {
        currentSwipe.ScaleTo(Vector2.zero, 0.1f, actionToEnd);
    }

    private void ScaleMax(Action actionToEnd = null)
    {
        currentSwipe.ScaleTo(Vector2.one, 0.1f, actionToEnd);
    }

    public override void DeactivateAnimation()
    {
        currentSwipe?.KillAllTweens();
        currentSwipe?.DestroyScale();
    }
}
