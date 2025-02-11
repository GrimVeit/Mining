using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTakePresenter
{
    private ShipTakeModel model;
    private ShipTakeView view;

    public ShipTakePresenter(ShipTakeModel model, ShipTakeView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        view.OnTakeShip += model.TakeShip;

        model.OnSetShip += view.SetShip;
        model.OnSelectShip += view.SelectShip;
        model.OnDeselectShip += view.DeselectShip;
    }

    public void Dispose()
    {
        view.OnTakeShip -= model.TakeShip;

        model.OnSetShip -= model.SetShip;
        model.OnSelectShip -= view.SelectShip;
        model.OnDeselectShip -= view.DeselectShip;
    }

    #region Input

    public event Action<int> OnTakeShip
    {
        add { model.OnTakeShip += value; }
        remove { model.OnTakeShip -= value; }
    }

    public void SetShip(Ship ship)
    {
        model.SetShip(ship);
    }

    public void SelectShip(Ship ship)
    {
        model.SelectShip(int.Parse(ship.GetID()));
    }

    public void DeselectShip(Ship ship)
    {
        model.DeselectShip(int.Parse(ship.GetID()));
    }

    #endregion
}
