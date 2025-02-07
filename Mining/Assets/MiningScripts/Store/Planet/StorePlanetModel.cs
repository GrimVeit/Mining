using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class StorePlanetModel
{
    public event Action<Planets> OnSetPlanets;

    //public event Action<int> OnSelectRocketOpenPlanet_Index;
    //public event Action<int> OnSelectNoneRocketOpenPlanet_Index;
    //public event Action<int> OnDeselectRocketOpenPlanet_Index;
    //public event Action<int> OnDeselectNoneRocketOpenPlanet_Index;

    public event Action<Planet> OnSelectRocketOpenPlanet_Value;
    public event Action<Planet> OnSelectNoneRocketOpenPlanet_Value;
    public event Action<Planet> OnDeselectRocketOpenPlanet_Value;
    public event Action<Planet> OnDeselectNoneRocketOpenPlanet_Value;

    public event Action<Planet> OnSelectClosePlanet_Value;
    public event Action<Planet> OnDeselectClosePlanet_Value;
    public event Action<Planet> OnSelectOpenPlanet_Value;
    public event Action<Planet> OnDeselectOpenPlanet_Value;


    public event Action<Planet> OnSelectPlanet_Value;
    public event Action<Planet> OnDeselectPlanet_Value;

    public event Action OnSelectPlanet;
    public event Action OnDeselectPlanet;

    public event Action<Planet> OnBuyPlanet_Value;
    public event Action<Planet> OnBuyRocketToPlanet_Value;

    private Planets currentPlanets;

    private Planet currentPlanet;

    public void SetGalaxy(Galaxy galaxy)
    {
        currentPlanets = galaxy.planets;

        for (int i = 0; i < currentPlanets.planets.Count; i++)
        {
            if(i == 0)
            {
                currentPlanets.planets[i].SetPlanetData(new PlanetData(false));
            }
            else
            {
                currentPlanets.planets[i].SetPlanetData(new PlanetData(false));
            }
        }

        OnSetPlanets?.Invoke(currentPlanets);
    }

    public void SelectPlanet(int id)
    {
        if(currentPlanet != null)
        {
            if (!currentPlanet.PlanetData.IsOpen)
            {
                OnDeselectClosePlanet_Value?.Invoke(currentPlanet);
            }
            else
            {
                if (currentPlanet.RocketPlanetData == null)
                {
                    OnDeselectNoneRocketOpenPlanet_Value?.Invoke(currentPlanet);
                }
                else
                {
                    OnDeselectRocketOpenPlanet_Value?.Invoke(currentPlanet);
                }

                OnDeselectOpenPlanet_Value?.Invoke(currentPlanet);
            }

            OnDeselectPlanet_Value?.Invoke(currentPlanet);
            OnDeselectPlanet?.Invoke();
        }



        currentPlanet = currentPlanets.GetPlanetById(id.ToString());


        if(currentPlanet.RocketPlanetData != null)
        {
            Debug.Log($"Название ракеты у планеты {currentPlanet.NamePlanet} - {currentPlanet.RocketPlanetData.Rocket.Name}");
        }
        else
        {
            Debug.Log($"У планеты {currentPlanet.NamePlanet} нет ракеты");
        }



        if (!currentPlanet.PlanetData.IsOpen)
        {
            OnSelectClosePlanet_Value?.Invoke(currentPlanet);
        }
        else
        {
            if (currentPlanet.RocketPlanetData == null)
            {
                OnSelectNoneRocketOpenPlanet_Value?.Invoke(currentPlanet);
            }
            else
            {
                OnSelectRocketOpenPlanet_Value?.Invoke(currentPlanet);
            }

            OnSelectOpenPlanet_Value?.Invoke(currentPlanet);
        }

        OnSelectPlanet_Value?.Invoke(currentPlanet);
        OnSelectPlanet?.Invoke();
    }

    public void BuyPlanet(int planetID)
    {
        var planet = currentPlanets.GetPlanetById(planetID.ToString());

        planet.PlanetData.Open();

        OnBuyPlanet_Value.Invoke(planet);

        SelectPlanet(planetID);
    }

    public void BuyRocketToPlanet(int planetID, Rocket rocket)
    {
        Debug.Log(planetID);

        var planet = currentPlanets.GetPlanetById(planetID.ToString());

        planet.SetRocketPlanetData(new RocketPlanetData(rocket));

        OnBuyRocketToPlanet_Value?.Invoke(planet);

        SelectPlanet(planetID);
    }

    public void UpgradeSpeedRocket(int planetID, float speed)
    {
        var planet = currentPlanets.GetPlanetById(planetID.ToString());

        planet.RocketPlanetData.SetSpeed(speed);

        SelectPlanet(planetID);
    }

    public void UpgradeCapacityRocket(int planetID, int capacity)
    {
        var planet = currentPlanets.GetPlanetById(planetID.ToString());

        planet.RocketPlanetData.SetCapacity(capacity);

        SelectPlanet(planetID);
    }

    public void SelectSecondPlanet()
    {
        int currentIndex = currentPlanets.planets.IndexOf(currentPlanet);
        int nextIndex = (currentIndex + 1) % currentPlanets.planets.Count;



        SelectPlanet(int.Parse(currentPlanets.planets[nextIndex].GetID()));
    }
}

[Serializable]
public class PlanetData
{
    public bool IsOpen;

    public PlanetData(bool isOpen)
    {
        this.IsOpen = isOpen;
    }

    public void Open()
    {
        IsOpen = true;
    }
}

public class RocketPlanetData
{
    public int RocketID { get; private set; }
    public Rocket Rocket { get; private set; }
    public int UpgradeLevelSpeed { get; private set; }
    public int UpgradeLevelCapacity { get; private set; }
    public float Speed { get; private set; }
    public int Capacity { get; private set; }

    public RocketPlanetData(Rocket rocket)
    {
        this.Rocket = rocket;

        RocketID = int.Parse(Rocket.GetID());
        Capacity = Rocket.BaseLoadCapacity;
        Speed = Rocket.BaseSpeed;

        UpgradeLevelCapacity = 0;
        UpgradeLevelSpeed = 0;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;

        UpgradeLevelSpeed += 1;
    }

    public void SetCapacity(int capacity)
    {
        Capacity = capacity;

        UpgradeLevelCapacity += 1;
    } 
}
