using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RocketBuyInteractive : MonoBehaviour, IPointerClickHandler
{
    public event Action<Rocket> OnChooseRocket;

    public int ID => int.Parse(rocket.GetID());

    [SerializeField] private Image imageSelectRocket;
    [SerializeField] private TextMeshProUGUI textNameRocket;
    [SerializeField] private TextMeshProUGUI textBaseLoadCapacity;

    private Rocket rocket;

    public void SetData(Rocket rocket)
    {
        this.rocket = rocket;

        textNameRocket.text = this.rocket.Name;
        textBaseLoadCapacity.text = this.rocket.BaseLoadCapacity.ToString();
    }

    public void SelectRocket()
    {
        imageSelectRocket.enabled = true;
    }

    public void DeselectRocket()
    {
        imageSelectRocket.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnChooseRocket?.Invoke(rocket);
    }
}
