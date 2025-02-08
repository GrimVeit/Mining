using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlanetRocketVisualView : View
{
    [SerializeField] private Transform transformShipRocketPlanets;
    [SerializeField] private List<Transform> transformPositions = new List<Transform>();

    private Transform currentTransformPosition;

    private Tween tweenMove;
    private Tween tweenScale;

    public void SelectLow(int index)
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[index];

        transformShipRocketPlanets.SetParent(currentTransformPosition);

        tweenScale = transformShipRocketPlanets.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f);
        transformShipRocketPlanets.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void SelectMiddle(int index)
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[index];

        transformShipRocketPlanets.SetParent(currentTransformPosition);

        tweenScale = transformShipRocketPlanets.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
        transformShipRocketPlanets.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void SelectHigh(int index)
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[index];

        transformShipRocketPlanets.SetParent(currentTransformPosition);

        tweenScale = transformShipRocketPlanets.DOScale(Vector3.one, 0.2f);
        transformShipRocketPlanets.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void SelectShip()
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[6];

        transformShipRocketPlanets.SetParent(currentTransformPosition);

        tweenScale = transformShipRocketPlanets.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
        transformShipRocketPlanets.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void SelectDefault()
    {
        tweenScale?.Kill();
        tweenMove?.Kill();

        currentTransformPosition = transformPositions[7];

        transformShipRocketPlanets.SetParent(currentTransformPosition);

        tweenScale = transformShipRocketPlanets.DOScale(Vector3.one, 0.2f);
        transformShipRocketPlanets.DOLocalMove(Vector3.zero, 0.2f);
    }
}
