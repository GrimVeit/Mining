using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRocketVisualModel
{
    public event Action<int> OnSelectHighPlanet;
    public event Action<int> OnSelectLowPlanet;
    public event Action<int> OnSelectMiddlePlanet;

    public event Action OnSelectShip;
    public event Action OnSelectDefault;

    public void Select(int id, PlanetType type)
    {
        switch (type)
        {
            case PlanetType.High:
                OnSelectHighPlanet?.Invoke(id);
                break;
            case PlanetType.Low:
                OnSelectLowPlanet?.Invoke(id);
                break;
            case PlanetType.Middle:
                OnSelectMiddlePlanet?.Invoke(id);
                break;
        }
    }

    public void SelectShip()
    {
        OnSelectShip?.Invoke();
    }

    public void SelectDefault()
    {
        OnSelectDefault?.Invoke();
    }
}
