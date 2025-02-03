using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketBuyModel
{
    public event Action OnOpenBuyPanel;
    public event Action OnCloseBuyPanel;

    public event Action<Rocket> OnSelectRocket;
    public event Action<Rocket> OnDeselectRocket;

    public event Action<int, Rocket> OnBuyRocket;

    public event Action<Rocket> OnVisualizeRocket;

    public List<Rocket> openRockets = new List<Rocket>();

    private int planetID;

    private Rocket currentRocket;

    public void SetRockets(Rocket rocket)
    {
        openRockets.Add(rocket);

        OnVisualizeRocket?.Invoke(rocket);
    }

    public void SelectRocketPlanet()
    {
        OnCloseBuyPanel?.Invoke();
    }

    public void SelectNoneRocketPlanet(int planetID)
    {
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
        OnSelectRocket?.Invoke(currentRocket);
    }

    public void BuyRocket()
    {
        OnBuyRocket?.Invoke(planetID, currentRocket);
    }
}
