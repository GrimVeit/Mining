using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IIdentify
{
    public string GetID() => id;
    public event Action<Vector2> OnGetDirection;

    [SerializeField] private string id;
    [SerializeField] private Image image;

    private Vector2 currentPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        currentPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnGetDirection(eventData.position - currentPos);
    }

    public void Activate()
    {
        image.gameObject.SetActive(true);
        image.raycastTarget = true;
    }

    public void Deactivate()
    {
        image.gameObject.SetActive(false);
        image.raycastTarget = false;
    }
}
