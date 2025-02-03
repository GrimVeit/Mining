using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBuyPresenter
{
    private PlanetBuyModel model;
    private PlanetBuyView view;

    public PlanetBuyPresenter(PlanetBuyModel model, PlanetBuyView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnBuyPlanet += model.BuyPlanet;

        model.OnActivate += view.ActivatePlanetBuyDisplay;
        model.OnDeactivate += view.DeactivatePlanetBuyDisplay;
        model.OnSetPlanet += view.SetPlanetData;
    }

    private void DeactivateEvents()
    {
        view.OnBuyPlanet -= model.BuyPlanet;

        model.OnActivate -= view.ActivatePlanetBuyDisplay;
        model.OnDeactivate -= view.DeactivatePlanetBuyDisplay;
        model.OnSetPlanet -= view.SetPlanetData;
    }

    #region Input

    public event Action<int> OnBuyPlanet
    {
        add { model.OnBuyPlanet += value; }
        remove { model.OnBuyPlanet -= value; }
    }

    public void SetClosePlanet(Planet planet)
    {
        model.SetClosePlanet(planet);
    }

    public void SetOpenPlanet(Planet planet)
    {
        model.SetOpenPlanet();
    }

    #endregion
}
