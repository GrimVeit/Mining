using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RocketTransfer : MonoBehaviour
{
    public event Action OnEndMoveToShip;
    public event Action OnEndMoveToPlanet;

    [SerializeField] private Transform transformRocket;


    [SerializeField] private Transform transformShip;
    [SerializeField] private Transform transformPlanet;

    private Tween tweenMove;

    [SerializeField] private float speed;

    private Transform targetRotate;

    private void Awake()
    {
        transformRocket.position = transformShip.position;

        MoveToPlanet();
    }

    public void SetData(Transform transformShip, Transform transformPlanet)
    {
        this.transformShip = transformShip;
        this.transformPlanet = transformPlanet;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void MoveToShip()
    {
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToPlanet();
        }
    }


    private void RotateTo()
    {
        Vector2 direction = (targetRotate.position - transformRocket.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transformRocket.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
