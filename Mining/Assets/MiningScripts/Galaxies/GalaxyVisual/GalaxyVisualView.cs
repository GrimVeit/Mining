using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GalaxyVisualView : View
{
    [SerializeField] private Transform transformGalaxies;
    [SerializeField] private List<Transform> transformPositions = new List<Transform>();

    private Transform currentTransformPosition;

    private Tween tweenMove;
    private Tween tweenScale;

    public void Select(int index)
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[index];

        transformGalaxies.SetParent(currentTransformPosition);

        tweenScale = transformGalaxies.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
        tweenMove = transformGalaxies.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void SelectDefault()
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[5];

        transformGalaxies.SetParent(currentTransformPosition);

        tweenScale = transformGalaxies.DOScale(Vector3.one, 0.2f);
        tweenMove = transformGalaxies.DOLocalMove(Vector3.zero, 0.2f);
    }
}
