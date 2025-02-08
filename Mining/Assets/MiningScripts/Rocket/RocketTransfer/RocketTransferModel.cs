using System;

public class RocketTransferModel
{
    public event Action<ResourceType, int> OnSendResources;

    public event Action<Planet, IPlanetResource> OnSpawnRocket;
    public event Action<int> OnReturnRocketToShip;

    public IPlanetResourceProvider planetResourceProvider;

    public RocketTransferModel(IPlanetResourceProvider resourceProvider)
    {
        planetResourceProvider = resourceProvider;
    }

    public void SpawnRocket(Planet planet)
    {
        OnSpawnRocket?.Invoke(planet, planetResourceProvider.GetResource(int.Parse(planet.GetID())));
    }

    public void SendResources(ResourceType resourceType, int count)
    {
        OnSendResources?.Invoke(resourceType, count);
    }

    public void ReturnRocketToShip(int id)
    {
        OnReturnRocketToShip?.Invoke(id);
    }
}
