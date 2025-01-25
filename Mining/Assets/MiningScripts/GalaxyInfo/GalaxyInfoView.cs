using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyInfoView : MonoBehaviour
{
    [SerializeField] private Transform transformContentNamePlanets;
    [SerializeField] private Transform transformContentNameResources;

    [SerializeField] private GridPlanet gridPlanetPrefab;
    [SerializeField] private GridResource gridResourcePrefab;

    public void SetGalaxyInfo(Galaxy galaxy)
    {
       
        while(transformContentNamePlanets.childCount > 0)
        {
            Destroy(transformContentNamePlanets.GetChild(0).gameObject);
        }

        while (transformContentNameResources.childCount > 0)
        {
            Destroy(transformContentNameResources.GetChild(0).gameObject);
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
