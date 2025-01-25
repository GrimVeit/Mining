using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Description : MonoBehaviour
{
    public Transform Transform => transformDescription;

    [SerializeField] private Transform transformDescription;

    private Tween tweenScale;

    public void ScaleTo(Vector3 vector, float time, Action actionToEnd = null)
    {
        tweenScale?.Kill();

        tweenScale = transformDescription.DOScale(vector, time).OnComplete(()=> actionToEnd?.Invoke());
    }

    public void SetScale(Vector3 vector)
    {
        transformDescription.localScale = vector;
    }

    public void Destroy()
    {
        Destroy(transformDescription.gameObject);
    }
}
