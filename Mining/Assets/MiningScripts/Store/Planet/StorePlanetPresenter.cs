using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePlanetPresenter
{
    private StorePlanetModel model;

    public StorePlanetPresenter(StorePlanetModel planetModel)
    {
        this.model = planetModel;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }

    #region Input

    public event Action<Planet> OnSelectRocketPlanet_Value
    {
        add { model.OnSelectRocketOpenPlanet_Value += value; }
        remove { model.OnSelectRocketOpenPlanet_Value -= value; }
    }

    public event Action<Planet> OnSelectNoneRocketPlanet_Value
    {
        add { model.OnSelectNoneRocketOpenPlanet_Value += value; }
        remove { model.OnSelectNoneRocketOpenPlanet_Value -= value; }
    }

    public event Action<Planet> OnDeselectRocketPlanet_Value
    {
        add { model.OnDeselectRocketOpenPlanet_Value += value; }
        remove { model.OnDeselectRocketOpenPlanet_Value -= value; }
    }

    public event Action<Planet> OnDeselectNoneRocketPlanet_Value
    {
        add { model.OnDeselectNoneRocketOpenPlanet_Value += value; }
        remove { model.OnDeselectNoneRocketOpenPlanet_Value -= value; }
    }



    public event Action<Planet> OnSelectClosePlanet_Value
    {
        add { model.OnSelectClosePlanet_Value += value; }
        remove { model.OnSelectClosePlanet_Value -= value; }
    }

    public event Action<Planet> OnDeselectClosePlanet_Value
    {
        add { model.OnDeselectClosePlanet_Value += value; }
        remove { model.OnDeselectClosePlanet_Value -= value; }
    }

    public event Action<Planet> OnSelectOpenPlanet_Value
    {
        add { model.OnSelectOpenPlanet_Value += value; }
        remove { model.OnSelectOpenPlanet_Value -= value; }
    }

    public event Action<Planet> OnDeselectOpenPlanet_Value
    {
        add { model.OnDeselectOpenPlanet_Value += value; }
        remove { model.OnDeselectOpenPlanet_Value -= value; }
    }



    public event Action<Planets> OnSetPlanets
    {
        add { model.OnSetPlanets += value; }
        remove { model.OnSetPlanets -= value; }
    }

    public event Action<Planet> OnSelectPlanet_Value
    {
        add { model.OnSelectPlanet_Value += value; }
        remove { model.OnSelectPlanet_Value -= value; }
    }

    public event Action<Planet> OnDeselectPanel_Value
    {
        add { model.OnDeselectPlanet_Value += value; }
        remove { model.OnDeselectPlanet_Value -= value; }
    }

    public event Action OnSelectPlanet
    {
        add { model.OnSelectPlanet += value; }
        remove { model.OnSelectPlanet -= value; }
    }

    public event Action OnDeselectPlanet
    {
        add { model.OnDeselectPlanet += value; }
        remove { model.OnDeselectPlanet -= value; }
    }




    public event Action<Planet> OnBuyPlanet_Value
    {
        add { model.OnBuyPlanet_Value += value; }
        remove { model.OnBuyPlanet_Value -= value; }
    }

    public event Action<Planet> OnBuyRocketToPlanet_Value
    {
        add { model.OnBuyRocketToPlanet_Value += value; }
        remove { model.OnBuyRocketToPlanet_Value -= value; }
    }



    public void SetGalaxy(Galaxy galaxy)
    {
        model.SetGalaxy(galaxy);
    }



    public void SelectPlanet(int id)
    {
        Debug.Log(id);

        model.SelectPlanet(id);
    }

    public void SelectSecondPlanet()
    {
        model.SelectSecondPlanet();
    }

    public void BuyPlanet(int id)
    {
        model.BuyPlanet(id);
    }

    public void BuyRocketToPlanet(int planetID, Rocket rocket)
    {
        model.BuyRocketToPlanet(planetID, rocket);
    }


    public void UpgradeRocketSpeed(int planetID, float value)
    {
        model.UpgradeSpeedRocket(planetID, value);
    }

    public void UpgradeRocketCapacity(int planetID, int value)
    {
        model.UpgradeCapacityRocket(planetID, value);
    }

    #endregion
}


