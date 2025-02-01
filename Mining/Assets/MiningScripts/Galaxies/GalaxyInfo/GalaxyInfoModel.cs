using System;
using System.Collections.Generic;

public class GalaxyInfoModel
{
    public event Action<Galaxy> OnSetGalaxy;

    public void SetGalaxy(Galaxy galaxy)
    {
        OnSetGalaxy?.Invoke(galaxy);
    }
}
