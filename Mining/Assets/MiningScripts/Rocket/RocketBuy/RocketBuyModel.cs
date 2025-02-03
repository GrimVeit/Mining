using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketBuyModel
{
    public event Action OnOpenBuyPanel;
    public event Action OnCloseBuyPanel;

    public event Action<Rocket, int> OnSelectRocket;
    public event Action<Rocket> OnDeselectRocket;

    public event Action<int, Rocket> OnBuyRocket;

    public event Action<Rocket> OnVisualizeRocket;

    public List<Rocket> openRockets = new List<Rocket>();

    private int planetID;

    private Rocket currentRocket;

    private IMoneyProvider moneyProvider;
    private RocketBuyLevelPrices prices;
    private int levelBuy = 0;

    public RocketBuyModel(RocketBuyLevelPrices prices, IMoneyProvider moneyProvider)
    {
        this.prices = prices;
        this.moneyProvider = moneyProvider;
    }

    public void SetRockets(Rocket rocket)
    {
        openRockets.Add(rocket);

        OnVisualizeRocket?.Invoke(rocket);
    }

    public void SelectRocketOpenPlanet()
    {
        OnCloseBuyPanel?.Invoke();
    }

    public void SelectClosePlanet()
    {
        OnCloseBuyPanel?.Invoke();
    }

    public void SelectNoneRocketOpenPlanet(int planetID)
    {

        Debug.Log(planetID);
        this.planetID = planetID;

        OnOpenBuyPanel?.Invoke();
    }

    public void SelectRocket(Rocket rocket)
    {
        if(currentRocket != null)
        {
            Debug.Log("Deselect - " + rocket.Name);
            OnDeselectRocket?.Invoke(currentRocket);
        }

        currentRocket = rocket;
        Debug.Log("Select - " + rocket.Name);
        OnSelectRocket?.Invoke(currentRocket, prices.rocketBuyLevelPrices.
            FirstOrDefault(data => data.BuyLevelNumber == levelBuy).rocketBuyPrices.
            FirstOrDefault(data => data.rocketID == int.Parse(currentRocket.GetID())).price);
    }

    public void BuyRocket()
    {
        if (moneyProvider.CanAfford(prices.rocketBuyLevelPrices.
            FirstOrDefault(data => data.BuyLevelNumber == levelBuy).rocketBuyPrices.
            FirstOrDefault(data => data.rocketID == int.Parse(currentRocket.GetID())).price))
        {
            levelBuy += 1;
            OnBuyRocket?.Invoke(planetID, currentRocket);

            OnDeselectRocket?.Invoke(currentRocket);
        }
    }
}
