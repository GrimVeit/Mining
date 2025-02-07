using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetResourceModel : MonoBehaviour
{
    public event Action<Planet, int, float> OnVisualizePlanetResourceData;

    private List<PlanetResource> planetResources = new List<PlanetResource>();
    private PlanetResource currentPlanetResource;

    public void SetPlanets(Planets planets)
    {
        for (int i = 0; i < planets.planets.Count; i++)
        {
            PlanetResource resource = new();
            resource.SetPlanet(planets.planets[i]);

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
        currentPlanetResource.OnChangePlanetResourceData -= ChangePlanetResourceData;
    }

    public IPlanetResource GetResource(int id)
    {
        return planetResources.FirstOrDefault(data => data.PlanetID() == id);
    }

    private void ChangePlanetResourceData(int currentCountMined, float persentMined)
    {
        OnVisualizePlanetResourceData?.Invoke(currentPlanetResource.CurrentPlanet, currentCountMined, persentMined);
    }
}
