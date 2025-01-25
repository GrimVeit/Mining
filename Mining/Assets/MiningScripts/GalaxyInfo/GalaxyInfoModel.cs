using System;
using System.Collections.Generic;

public class GalaxyInfoModel
{
    public event Action<Galaxy> OnSetGalaxy;

    private Galaxy currentGalaxy;

    public void SetGalaxy(Galaxy galaxy)
    {
        currentGalaxy = galaxy;
        OnSetGalaxy?.Invoke(currentGalaxy);
    }
}
