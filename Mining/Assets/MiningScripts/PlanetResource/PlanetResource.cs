using System;
using UnityEngine;

public class PlanetResource : MonoBehaviour
{
    public float ResourceCount { get; private set; }
    public event Action<float> OnRemoveResource;

    public void SetPlanet()
    {

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
