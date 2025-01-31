using System;
using System.Linq;

public class StorePlanetModel
{
    public event Action<Planets> OnSetPlanets;

    public event Action<Planet> OnSelectPlanet_Value;
    public event Action<Planet> OnDeselectPlanet_Value;
    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;


    private Planets currentPlanets;

    private Planet currentPlanet;

    public void SeyGalaxy(Galaxy galaxy)
    {
        currentPlanets = galaxy.planets;
        OnSetPlanets?.Invoke(currentPlanets);
    }

    public void SelectPlanet(int id)
    {
        if(currentPlanet != null)
        {
            OnDeselectPlanet_Value?.Invoke(currentPlanet);
            OnDeselectPlanet?.Invoke();
        }

        currentPlanet = GetPlanetById(id.ToString());
        OnSelectPlanet_Value?.Invoke(currentPlanet);
        OnSelectPlanet?.Invoke();
    }

    private Planet GetPlanetById(string id)
    {
        return currentPlanets.planets.FirstOrDefault(planet => planet.GetID() == id);
    }
}
