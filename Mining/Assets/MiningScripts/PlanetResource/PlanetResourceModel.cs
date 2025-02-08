using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetResourceModel
{
    private List<PlanetResource> planetResources = new List<PlanetResource>();
    private PlanetResource currentPlanetResource;

    public void SetPlanets(Planets planets)
    {
        for (int i = 0; i < planets.planets.Count; i++)
        {
            PlanetResource resource = new();
            resource.SetPlanet(planets.planets[i]);

            resource.OnEndResources += HandleEndResources;

            planetResources.Add(resource);
        }
    }

    public void SelectPlanet(Planet planet)
    {
        if(currentPlanetResource != null)
        {
            currentPlanetResource.OnChangePlanetResourceData -= ChangePlanetResourceData;
        }

        currentPlanetResource = planetResources.FirstOrDefault(data => data.PlanetID() == int.Parse(planet.GetID()));
        currentPlanetResource.OnChangePlanetResourceData += ChangePlanetResourceData;
        OnVisualizePlanetResourceData?.Invoke(currentPlanetResource.CurrentPlanet, currentPlanetResource.AllResourceCount() - currentPlanetResource.ResourceCount(), currentPlanetResource.PersentMined());
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        for (int i = 0; i < planetResources.Count; i++)
        {
            planetResources[i].OnEndResources -= HandleEndResources;
        }

        currentPlanetResource.OnChangePlanetResourceData -= ChangePlanetResourceData;
    }

    public IPlanetResource GetResource(int id)
    {
        return planetResources.FirstOrDefault(data => data.PlanetID() == id);
    }

    #region Input

    public event Action<Planet, int, float> OnVisualizePlanetResourceData;
    public event Action<int> OnEndResources;

    private void ChangePlanetResourceData(int currentCountMined, float persentMined)
    {
        OnVisualizePlanetResourceData?.Invoke(currentPlanetResource.CurrentPlanet, currentCountMined, persentMined);
    }

    private void HandleEndResources(int id)
    {
        OnEndResources?.Invoke(id);
    }

    #endregion
}
