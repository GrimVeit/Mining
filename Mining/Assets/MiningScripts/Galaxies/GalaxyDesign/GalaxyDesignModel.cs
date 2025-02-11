using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDesignModel
{
    public event Action<Galaxy> OnSetGalaxy;

    public void SetGalaxy(Galaxy galaxy)
    {
        OnSetGalaxy?.Invoke(galaxy);
    }
}
