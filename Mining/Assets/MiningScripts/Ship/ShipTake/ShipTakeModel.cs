using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTakeModel
{
    public event Action<Ship> OnSetShip;

    public event Action<int> OnSelectShip;
    public event Action<int> OnDeselectShip;

    public event Action<int> OnTakeShip;

    public void SetShip(Ship ship)
    {
        OnSetShip?.Invoke(ship);
    }

    public void SelectShip(int id)
    {
        OnSelectShip?.Invoke(id);
    }

    public void DeselectShip(int id)
    {
        OnDeselectShip?.Invoke(id);
    }

    public void TakeShip(int id)
    {
        OnTakeShip?.Invoke(id);
    }
}
