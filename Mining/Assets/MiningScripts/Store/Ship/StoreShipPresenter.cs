using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreShipPresenter
{
    private StoreShipModel model;

    public StoreShipPresenter(StoreShipModel model)
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

    public event Action<Ship> OnOpenShip
    {
        add { model.OnOpenShip += value; }
        remove { model.OnOpenShip -= value; }
    }

    public event Action<Ship> OnCloseShip
    {
        add { model.OnCloseShip += value; }
        remove { model.OnCloseShip -= value; }
    }




    public event Action<Ship> OnSelectOpenShip
    {
        add { model.OnSelectOpenShip += value; }
        remove { model.OnSelectOpenShip -= value; }
    }

    public event Action<Ship> OnSelectCloseShip
    {
        add { model.OnSelectCloseShip += value; }
        remove { model.OnSelectCloseShip -= value; }
    }





    public event Action<Ship> OnDeselectShip
    {
        add { model.OnDeselectShip += value; }
        remove { model.OnDeselectShip -= value; }
    }

    public event Action<Ship> OnSelectShip
    {
        add { model.OnSelectShip += value; }
        remove { model.OnSelectShip -= value; }
    }





    public void BuyShip(int id)
    {
        model.BuyShip(id);
    }

    public void SelectShip(int id)
    {
        model.SelectShip(id);
    }

    #endregion
}
