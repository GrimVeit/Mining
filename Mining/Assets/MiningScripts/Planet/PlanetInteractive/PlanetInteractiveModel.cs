using System;
using UnityEngine;

public class PlanetInteractiveModel
{
    public event Action<int> OnChoosePlanet_Value;
    public event Action OnChoosePlanet;

    public event Action<Planet> OnVisualizePlanet;

    public event Action<int> OnUnlockPlanet;

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
        OnChoosePlanet_Value?.Invoke(id);
        OnChoosePlanet?.Invoke();
    }

    public void Unlock(int planetID)
    {
        OnUnlockPlanet?.Invoke(planetID);
    }
}
