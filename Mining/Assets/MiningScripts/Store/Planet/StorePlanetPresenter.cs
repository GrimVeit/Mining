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

    public void SetGalaxy(Galaxy galaxy)
    {
        model.SeyGalaxy(galaxy);
    }



    public void SelectPlanet(int id)
    {
        Debug.Log(id);

        model.SelectPlanet(id);
    } 

    #endregion
}


