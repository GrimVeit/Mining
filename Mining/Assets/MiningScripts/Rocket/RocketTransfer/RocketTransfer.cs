using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RocketTransfer : MonoBehaviour
{
    public event Action OnEndMoveToShip;
    public event Action OnEndMoveToPlanet;

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
    private float capacity => planet.RocketPlanetData.Capacity;

    private Transform targetRotate;

    public void Initialize()
    {
        transformRocket.localPosition = Vector3.zero;

        MoveToPlanet();
    }

    public void SetData(Planet planet, Transform transformShip)
    {
        this.planet = planet;
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
        tweenMove = transformRocket.DOMove(transformShip.position, speed).OnUpdate(RotateTo).OnComplete(MoveToPlanet);
    }

    public void MoveToPlanet()
    {
        tweenMove?.Kill();

        targetRotate = transformPlanet;
        tweenMove = transformRocket.DOMove(transformPlanet.position, speed).OnUpdate(RotateTo).OnComplete(MoveToShip);
    }


    private void RotateTo()
    {
        Vector2 direction = (targetRotate.position - transformRocket.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transformRocket.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
