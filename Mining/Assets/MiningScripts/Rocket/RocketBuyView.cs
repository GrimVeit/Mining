using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketBuyView : View
{
    [SerializeField] private RocketBuyDisplay rocketBuyDisplay;
    [SerializeField] private Button buttonBuy;
    [SerializeField] private TextMeshProUGUI textPrice;

    public void Initialize()
    {
        rocketBuyDisplay.OnSelectRocket += HandleSelectRocket;
        rocketBuyDisplay.Initialize();

        buttonBuy.onClick.AddListener(HandleBuyRocket);
    }

    public void Dispose()
    {
        rocketBuyDisplay.OnSelectRocket -= HandleSelectRocket;
        rocketBuyDisplay.Dispose();

        buttonBuy.onClick.RemoveListener(HandleBuyRocket);
    }

    public void ActivateDisplay()
    {
        rocketBuyDisplay.ActivateDisplay();
    }

    public void DeactivateDisplay()
    {
        rocketBuyDisplay.DeactivateDisplay();
    }

    public void SetRocketVisualize(Rocket rocket)
    {
        rocketBuyDisplay.SetRocketVisualize(rocket);
    }

    public void SelectRocket(Rocket rocket)
    {
        rocketBuyDisplay.SelectRocket(rocket);
        textPrice.text = rocket.Price.ToString();
    }

    public void DeselectRocket(Rocket rocket)
    {
        rocketBuyDisplay.DeselectRocket(rocket);
    }

    #region Input

    public event Action OnBuyRocket;
    public event Action<Rocket> OnSelectRocket;

    private void HandleBuyRocket()
    {
        OnBuyRocket?.Invoke();
    }

    private void HandleSelectRocket(Rocket rocket)
    {
        OnSelectRocket?.Invoke(rocket);
    }

    #endregion
}
