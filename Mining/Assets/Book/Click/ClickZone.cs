using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickZone : MonoBehaviour, IPointerDownHandler
{
    public string GetID() => id;
    public event Action OnClick;

    [SerializeField] private string id;
    [SerializeField] private Image image;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
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
