using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyInfoView : View
{
    [SerializeField] private Transform transformContentNamePlanets;
    [SerializeField] private Transform transformContentNameResources;

    [SerializeField] private GridPlanet gridPlanetPrefab;
    [SerializeField] private GridResource gridResourcePrefab;

    public void SetGalaxyInfo(Galaxy galaxy)
    {

        for (int i = 0; i < transformContentNamePlanets.childCount; i++)
        {
            Destroy(transformContentNamePlanets.GetChild(i).gameObject);
        }

        for (int i = 0; i < transformContentNameResources.childCount; i++)
        {
            Destroy(transformContentNameResources.GetChild(i).gameObject);
        }

        for (int i = 0; i < galaxy.planets.planets.Count; i++)
        {
            var gridPlanet = Instantiate(gridPlanetPrefab, transformContentNamePlanets);
            gridPlanet.SetData(galaxy.planets.planets[i].NamePlanet);
        }

        for (int i = 0; i < galaxy.planets.planets.Count; i++)
        {
            var gridResource = Instantiate(gridResourcePrefab, transformContentNameResources);
            gridResource.SetData(galaxy.planets.planets[i].ResourceType.ToString());
        }
    }
}
