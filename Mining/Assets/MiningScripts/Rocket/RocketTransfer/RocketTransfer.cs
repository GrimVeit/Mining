using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RocketTransfer : MonoBehaviour
{
    public int ID => int.Parse(planet.GetID());
    public event Action<ResourceType, int> OnSendResources;

    [SerializeField] private Transform transformRocket;
    [SerializeField] private Image imageRocket;
    [SerializeField] private Sprite spriteStandard;
    [SerializeField] private Sprite spriteBronze;
    [SerializeField] private Sprite spriteSilver;
    [SerializeField] private Sprite spriteGold;

    private Transform transformShip;
    private Transform transformPlanet;

    private Tween tweenMove;

    private Planet planet;
    private float speed => 30 / planet.RocketPlanetData.Speed;
    private int capacity => planet.RocketPlanetData.Capacity;

    private Transform targetRotate;

    private IPlanetResource planetResource;

    private int currentCapacityBoat;

    public void Initialize()
    {
        transformRocket.localPosition = transformShip.localPosition;

        MoveToPlanet();
    }

    public void SetData(Planet planet, IPlanetResource planetResource, Transform transformShip)
    {
        this.planet = planet;
        this.planetResource = planetResource;
        this.transformShip = transformShip;
        this.transformPlanet = planet.interactivePosition.TransformPlanet;

        switch (planet.RocketPlanetData.RocketID)
        {
            case 0:
                imageRocket.sprite = spriteStandard;
                break;
            case 1:
                imageRocket.sprite = spriteSilver;
                break;
            case 2:
                imageRocket.sprite = spriteBronze;
                break;
            case 3:
                imageRocket.sprite = spriteGold;
                break;
        }
    }

    public void MoveToShip()
    {
        Debug.Log(speed);
        tweenMove?.Kill();

        targetRotate = transformShip;
        tweenMove = transformRocket.DOLocalMove(transformShip.localPosition, speed).OnUpdate(RotateTo).OnComplete(SendResources);
    }

    public void MoveToPlanet()
    {
        tweenMove?.Kill();

        targetRotate = transformPlanet;
        tweenMove = transformRocket.DOLocalMove(transformPlanet.localPosition, speed).OnUpdate(RotateTo).OnComplete(CalculateResource);
    }

    private void CalculateResource()
    {
        if (planetResource.CanAfford(capacity))
        {
            currentCapacityBoat = capacity;
        }
        else
        {
            currentCapacityBoat = planetResource.ResourceCount();
        }

        planetResource.PickUpResource(currentCapacityBoat);

        MoveToShip();
    }

    private void SendResources()
    {
        OnSendResources?.Invoke(planet.ResourceType, currentCapacityBoat);

        MoveToPlanet();
    }


    private void RotateTo()
    {
        Vector2 direction = (targetRotate.position - transformRocket.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transformRocket.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
