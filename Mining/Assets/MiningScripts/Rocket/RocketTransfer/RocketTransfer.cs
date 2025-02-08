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

    private bool isActive = true;

    public void Initialize()
    {
        transformRocket.localPosition = transformShip.localPosition;

        MoveToPlanet(CalculateResource);
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

    public void MoveToShip(Action actionToEnd = null)
    {
        //Debug.Log(speed);
        tweenMove?.Kill();
 
        targetRotate = transformShip;
        tweenMove = transformRocket.DOLocalMove(transformShip.localPosition, speed).OnUpdate(RotateTo).OnComplete(()=> actionToEnd?.Invoke());
    }

    public void MoveToPlanet(Action actionToEnd = null)
    {
        tweenMove?.Kill();

        targetRotate = transformPlanet;
        tweenMove = transformRocket.DOLocalMove(transformPlanet.localPosition, speed).OnUpdate(RotateTo).OnComplete(()=> actionToEnd?.Invoke());
    }

    public void ReturnToShip()
    {
        if(!isActive) return;

        isActive = false;

        Debug.Log("REMOVE");

        MoveToShip(Deactivate);
    }

    private void Activate()
    {
        transformRocket.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        OnSendResources?.Invoke(planet.ResourceType, currentCapacityBoat);
        transformRocket.gameObject.SetActive(false);
    }





    private void CalculateResource()
    {
        if(!isActive) return;

        if (planetResource.CanAfford(capacity))
        {
            currentCapacityBoat = capacity;
        }
        else
        {
            currentCapacityBoat = planetResource.ResourceCount();
        }

        planetResource.PickUpResource(currentCapacityBoat);

        MoveToShip(SendResources);
    }

    private void SendResources()
    {
        if (!isActive) return;

        OnSendResources?.Invoke(planet.ResourceType, currentCapacityBoat);

        MoveToPlanet(CalculateResource);
    }






    private void RotateTo()
    {
        Vector2 direction = (targetRotate.position - transformRocket.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transformRocket.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
