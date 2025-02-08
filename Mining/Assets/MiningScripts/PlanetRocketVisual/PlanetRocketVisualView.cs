using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlanetRocketVisualView : View
{
    [SerializeField] private Transform transformShipRocketPlanets;
    [SerializeField] private List<Transform> transformPositions = new List<Transform>();

    private Transform currentTransformPosition;

    public void MoveTo(int index)
    {
        currentTransformPosition = transformPositions[index];

        transformShipRocketPlanets.DOLocalMove(currentTransformPosition.localPosition, 0.2f);
    }
}
