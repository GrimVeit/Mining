using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRocketVisualModel
{
    public event Action<int> OnSelect;

    public void Select(int id)
    {
        OnSelect?.Invoke(id);
    }

    public void SelectShip()
    {
        OnSelect?.Invoke(6);
    }

    public void SelectDefault()
    {
        OnSelect?.Invoke(7);
    }
}
