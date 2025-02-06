using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetRocketUpgradeModel
{
    public event Action<int, float> OnUpgradeSpeed;
    public event Action<int, float> OnUpgradeCapacity;

    public event Action OnActivateDisplay;
    public event Action OnDeactivateDisplay;

    public event Action<int> OnActivateButtonSpeed;
    public event Action OnDeactivateButtonSpeed;
    public event Action<int> OnActivateButtonCapacity;
    public event Action OnDeactivateButtonCapacity;

    public event Action<RocketPlanetData> OnVisualizeRocketData;

    private RocketUpgradeLevelPrices upgradeLevelPrices;

    private RocketUpgradeLevelPrice upgradeSecondLevelSpeed;
    private RocketUpgradeLevelPrice upgradeSecondLevelCapacity;

    private Planet currentPlanet;

    private IMoneyProvider moneyProvider;

    public PlanetRocketUpgradeModel(RocketUpgradeLevelPrices upgradeLevelPrices)
    {
        this.upgradeLevelPrices = upgradeLevelPrices;
    }

    public void SetRocketPlanet(Planet planet)
    {
        OnDeactivateButtonCapacity?.Invoke();
        OnDeactivateButtonSpeed?.Invoke();

        currentPlanet = planet;

        upgradeSecondLevelCapacity = upgradeLevelPrices.rocketUpgradeLevelPrices
            .FirstOrDefault(data => data.UpgradeLevelNumber == currentPlanet.RocketPlanetData.UpgradeLevelCapacity + 1);

        upgradeSecondLevelSpeed = upgradeLevelPrices.rocketUpgradeLevelPrices
            .FirstOrDefault(data => data.UpgradeLevelNumber == currentPlanet.RocketPlanetData.UpgradeLevelSpeed + 1);

        Debug.Log($"Следующий уровень прокачки грузоподъёмности - {upgradeSecondLevelCapacity.UpgradeLevelNumber}");

        OnVisualizeRocketData?.Invoke(currentPlanet.RocketPlanetData);

        OnActivateDisplay?.Invoke();

    }

    public void SetNoneRocket()
    {
        OnDeactivateDisplay?.Invoke();
    }

    public void SelectSpeed()
    {
        if (upgradeSecondLevelCapacity == null)
        {
            OnDeactivateButtonCapacity?.Invoke();
            OnDeactivateButtonSpeed?.Invoke();
        }
        else
        {
            //Debug.Log(upgradeSecondLevelSpeed.rocketUpgradeSpeedPrices.FirstOrDefault(data => data.rocketID))
            OnActivateButtonSpeed?.Invoke(upgradeSecondLevelSpeed.rocketUpgradeSpeedPrices.FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).price);
            OnDeactivateButtonCapacity?.Invoke();
        }
    }

    public void SelectCapacity()
    {
        if (upgradeSecondLevelCapacity == null)
        {
            OnDeactivateButtonCapacity?.Invoke();
            OnDeactivateButtonSpeed?.Invoke();
        }
        else
        {
            OnActivateButtonSpeed?.Invoke(upgradeSecondLevelCapacity.rocketUpgradeCapacityPrices.FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).price);
            OnDeactivateButtonCapacity?.Invoke();
        }
    }

    public void UpgradeSpeed()
    {
        OnUpgradeSpeed?.Invoke(int.Parse(currentPlanet.GetID()), 
            upgradeSecondLevelSpeed.rocketUpgradeSpeedPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).speedValue);
    }

    public void UpgradeCapacity()
    {
        OnUpgradeCapacity?.Invoke(int.Parse(currentPlanet.GetID()),
            upgradeSecondLevelSpeed.rocketUpgradeCapacityPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).capacityValue);
    }
}
