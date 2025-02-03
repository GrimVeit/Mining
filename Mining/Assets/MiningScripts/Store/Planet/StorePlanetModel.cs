using System;
using System.Linq;
using UnityEngine;

public class StorePlanetModel
{
    public event Action<Planets> OnSetPlanets;

    public event Action<int> OnSelectRocketOpenPlanet_Index;
    public event Action<int> OnSelectNoneRocketOpenPlanet_Index;
    public event Action<int> OnDeselectRocketOpenPlanet_Index;
    public event Action<int> OnDeselectNoneRocketOpenPlanet_Index;

    public event Action<Planet> OnSelectClosePlanet;
    public event Action<Planet> OnDeselectClosePlanet;


    public event Action<Planet> OnSelectPlanet_Value;
    public event Action<Planet> OnDeselectPlanet_Value;
    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;


    private Planets currentPlanets;

    private Planet currentPlanet;

    public void SetGalaxy(Galaxy galaxy)
    {
        currentPlanets = galaxy.planets;

        for (int i = 0; i < currentPlanets.planets.Count; i++)
        {
            currentPlanets.planets[i].SetData(new PlanetData(false, false));
        }

        OnSetPlanets?.Invoke(currentPlanets);
    }

    public void SelectPlanet(int id)
    {
        if(currentPlanet != null)
        {
            if (!currentPlanet.PlanetData.IsOpen) { }

            if (currentPlanet.PlanetData.Rocket == null)
            {
                OnDeselectNoneRocketOpenPlanet_Index?.Invoke(int.Parse(currentPlanet.GetID()));
            }
            else
            {
                OnDeselectRocketOpenPlanet_Index?.Invoke(int.Parse(currentPlanet.GetID()));
            }

            OnDeselectPlanet_Value?.Invoke(currentPlanet);
            OnDeselectPlanet?.Invoke();
        }

        currentPlanet = currentPlanets.GetPlanetById(id.ToString());

        if(currentPlanet.PlanetData.Rocket != null)
        {
            Debug.Log($"Название ракеты у планеты {currentPlanet.NamePlanet} - {currentPlanet.PlanetData.Rocket.Name}");
        }
        else
        {
            Debug.Log($"У планеты {currentPlanet.NamePlanet} нет ракеты");
        }


        if (currentPlanet.PlanetData.Rocket == null)
        {
            OnSelectNoneRocketOpenPlanet_Index?.Invoke(int.Parse(currentPlanet.GetID()));
        }
        else
        {
            OnSelectRocketOpenPlanet_Index?.Invoke(int.Parse(currentPlanet.GetID()));
        }

        OnSelectPlanet_Value?.Invoke(currentPlanet);
        OnSelectPlanet?.Invoke();
    }

    public void BuyRocketToPlanet(int planetID, Rocket rocket)
    {
        var planet = currentPlanets.GetPlanetById(planetID.ToString());

        planet.PlanetData.SetRocket(rocket);

        SelectPlanet(int.Parse(currentPlanet.GetID()));
    }
}

[Serializable]
public class PlanetData
{
    public bool IsOpen;
    public bool IsRocketFly;
    public Rocket Rocket;

    public PlanetData(bool isOpen, bool isRocketFly)
    {
        this.IsOpen = isOpen;
        this.IsRocketFly = isRocketFly;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void RocketFly()
    {
        IsRocketFly = true;
    }

    public void SetRocket(Rocket rocket)
    {
        this.Rocket = rocket;
    }
}
