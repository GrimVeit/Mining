using System;
using UnityEngine;

public class PlanetResource
{
    public float ResourceCount { get; private set; }
    public event Action<float> OnChangeResource;

    private Planet currentPlanet;

    public void SetPlanet(Planet planet)
    {
        currentPlanet = planet;
    }

    public void PickUpResource(int count)
    {
        if(ResourceCount >= count)
        {

        }
    }

    public bool CanAfford(int count)
    {
        return ResourceCount >= count;
    }
}

public interface IPlanetResource
{
    public bool CanAfford(int count);
}
