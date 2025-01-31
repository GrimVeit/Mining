using System;
using UnityEngine;

public class PlanetInteractiveModel
{
    public event Action<int> OnChoosePlanet;

    public event Action<Planet> OnVisualizePlanet;

    private Planets planets;

    public void SetPlanets(Planets planets)
    {
        this.planets = planets;

        Debug.Log(planets.planets.Count);

        VisualizePlanets();
    }

    private void VisualizePlanets()
    {
        for (int i = 0; i < planets.planets.Count; i++)
        {
            OnVisualizePlanet?.Invoke(planets.planets[i]);
        }
    }

    public void ChoosePlanet(int id)
    {
        OnChoosePlanet?.Invoke(id);
    }
}
