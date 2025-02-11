using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTakePresenter
{
    private RocketTakeModel model;
    private RocketTakeView view;

    public RocketTakePresenter(RocketTakeModel model, RocketTakeView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnBuyRocket += model.BuyRocket;

        model.OnSetOpenRocket += view.SetOpenRocket;
        model.OnSetCloseRocket += view.SetCloseRocket;
    }

    private void DeactivateEvents()
    {
        view.OnBuyRocket -= model.BuyRocket;

        model.OnSetOpenRocket -= view.SetOpenRocket;
        model.OnSetCloseRocket -= view.SetCloseRocket;
    }

    #region Input

    public event Action<int> OnBuyRocket
    {
        add { model.OnBuyRocket += value; }
        remove { model.OnBuyRocket -= value; }
    }

    public void SetCloseRocket(Rocket rocket)
    {
        model.SetCloseRocket(rocket);
    }

    public void SetOpenRocket(Rocket rocket)
    {
        model.SetOpenRocket(rocket);
    }

    #endregion
}
