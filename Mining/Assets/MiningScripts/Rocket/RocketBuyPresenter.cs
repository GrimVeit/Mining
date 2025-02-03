using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBuyPresenter
{
    private RocketBuyModel model;
    private RocketBuyView view;

    public RocketBuyPresenter(RocketBuyModel model, RocketBuyView view)
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
        view.OnSelectRocket += model.SelectRocket;
        view.OnBuyRocket += model.BuyRocket;

        model.OnOpenBuyPanel += view.ActivateDisplay;
        model.OnCloseBuyPanel += view.DeactivateDisplay;

        model.OnVisualizeRocket += view.SetRocketVisualize;

        model.OnSelectRocket += view.SelectRocket;
        model.OnDeselectRocket += view.DeselectRocket;
    }

    private void DeactivateEvents()
    {
        view.OnSelectRocket -= model.SelectRocket;
        view.OnBuyRocket -= model.BuyRocket;

        model.OnOpenBuyPanel -= view.ActivateDisplay;
        model.OnCloseBuyPanel -= view.DeactivateDisplay;

        model.OnVisualizeRocket -= view.SetRocketVisualize;

        model.OnSelectRocket -= view.SelectRocket;
        model.OnDeselectRocket -= view.DeselectRocket;
    }

    #region Input

    public event Action<int, Rocket> OnBuyRocket
    {
        add { model.OnBuyRocket += value; }
        remove { model.OnBuyRocket -= value; }
    }

    public void SetRocket(Rocket rocket)
    {
        model.SetRockets(rocket);
    }

    public void SelectRocketPlanet(int planeetID)
    {
        model.SelectRocketPlanet();
    }

    public void SelectNoneRocketPlanet(int planetID)
    {
        model.SelectNoneRocketPlanet(planetID);
    }

    #endregion
}
