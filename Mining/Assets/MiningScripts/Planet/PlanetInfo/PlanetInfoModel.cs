using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoModel
{
    public event Action<Planet> OnSetPlanet;

    public void SetPlanet(Planet planet)
    {
        OnSetPlanet?.Invoke(planet);
    }
}
