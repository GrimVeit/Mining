using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetRocketUpgradeInteractive : MonoBehaviour, IPointerClickHandler
{
    public event Action OnChoose;

    [SerializeField] private Image imageSelectResource;

    public void SelectUpgrade()
    {
        imageSelectResource.enabled = true;
    }

    public void DeselectUpgrade()
    {
        imageSelectResource.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnChoose?.Invoke();
    }
}
