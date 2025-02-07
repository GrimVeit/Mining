using System;

public class RocketTransferModel
{
    public event Action<Planet> OnActivateRocket;

    public void ActivateRocket(Planet planet)
    {
        OnActivateRocket?.Invoke(planet);
    }
}
