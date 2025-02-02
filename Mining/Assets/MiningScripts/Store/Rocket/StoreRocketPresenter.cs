using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreRocketPresenter
{
    private StoreRocketModel model;

    public StoreRocketPresenter(StoreRocketModel model)
    {
        this.model = model;
    }

    public void Initialize()
    {
        model.Initialize();
    }

    public void Dispose()
    {
        model.Dispose();
    }

    #region Input

    public event Action<Rocket> OnOpenRocket
    {
        add { model.OnOpenRocket += value; }
        remove { model.OnOpenRocket -= value; }
    }

    public event Action<Rocket> OnCloseRocket
    {
        add { model.OnCloseRocket += value; }
        remove { model.OnCloseRocket -= value; }
    }

    public void BuyRocket(int id)
    {
        model.BuyRocket(id);
    }

    public void SelectRocket(int id)
    {
        model.SelectRocket(id);
    }

    #endregion
}
