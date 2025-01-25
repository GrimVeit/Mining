using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClickAnimation : SwipeClickAnimation
{
    public override string GetID() => id;
    [SerializeField] private string id;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform transformMiddle;
    [SerializeField] private Vector3 vectorMin;

    private SwipeClick swipePrefab;

    private SwipeClick currentSwipe;

    public override void SetSwipe(SwipeClick swipe)
    {
        swipePrefab = swipe;
    }

    public override void ActivateAnimation()
    {
        currentSwipe = Instantiate(swipePrefab, parent);
        currentSwipe.transform.position = transformMiddle.position;
        currentSwipe.SetScale(Vector2.zero);
        ScaleToMax();
    }

    private void ScaleToMin()
    {
        currentSwipe.ScaleTo(vectorMin, 0.3f, ScaleToMax);
    }

    private void ScaleToMax()
    {
        currentSwipe.ScaleTo(Vector2.one, 0.8f, ScaleToMin);
    }

    public override void DeactivateAnimation()
    {
        currentSwipe?.KillAllTweens();
        currentSwipe?.DestroyScale();
    }
}
