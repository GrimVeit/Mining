using System;
using System.Linq;
using UnityEngine;

public class PlanetRocketUpgradeModel
{
    public event Action OnSelectSpeedInteractive;
    public event Action OnSelectCapacityInteractive;

    public event Action<int, float> OnUpgradeSpeed;
    public event Action<int, int> OnUpgradeCapacity;

    public event Action OnActivateDisplay;
    public event Action OnDeactivateDisplay;

    public event Action OnAllDeactivated;
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

    public PlanetRocketUpgradeModel(RocketUpgradeLevelPrices upgradeLevelPrices, IMoneyProvider moneyProvider)
    {
        this.upgradeLevelPrices = upgradeLevelPrices;
        this.moneyProvider = moneyProvider;
    }

    public void SetRocketPlanet(Planet planet)
    {
        OnAllDeactivated?.Invoke();

        currentPlanet = planet;

        upgradeSecondLevelCapacity = upgradeLevelPrices.rocketUpgradeLevelPrices
            .FirstOrDefault(data => data.UpgradeLevelNumber == currentPlanet.RocketPlanetData.UpgradeLevelCapacity + 1);

        upgradeSecondLevelSpeed = upgradeLevelPrices.rocketUpgradeLevelPrices
            .FirstOrDefault(data => data.UpgradeLevelNumber == currentPlanet.RocketPlanetData.UpgradeLevelSpeed + 1);

        if(upgradeSecondLevelSpeed != null)
              Debug.Log($"Следующий уровень прокачки скорости - {upgradeSecondLevelSpeed.UpgradeLevelNumber}");

        if(upgradeSecondLevelCapacity != null)
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
        if (upgradeSecondLevelSpeed == null)
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

        OnSelectSpeedInteractive?.Invoke();
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
            OnActivateButtonCapacity?.Invoke(upgradeSecondLevelCapacity.rocketUpgradeCapacityPrices.FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).price);
            OnDeactivateButtonSpeed?.Invoke();
        }

        OnSelectCapacityInteractive?.Invoke();
    }

    public void UpgradeSpeed()
    {
        int value = upgradeSecondLevelSpeed.rocketUpgradeSpeedPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).speedValue;

        int price = upgradeSecondLevelSpeed.rocketUpgradeSpeedPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).price;

        if (moneyProvider.CanAfford(price))
        {
            OnUpgradeSpeed?.Invoke(int.Parse(currentPlanet.GetID()), value);

            moneyProvider.SendMoney(-price);
        }
    }

    public void UpgradeCapacity()
    {
        int value = upgradeSecondLevelCapacity.rocketUpgradeCapacityPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).capacityValue;

        int price = upgradeSecondLevelCapacity.rocketUpgradeCapacityPrices
            .FirstOrDefault(data => data.rocketID == int.Parse(currentPlanet.RocketPlanetData.Rocket.GetID())).price;

        if (moneyProvider.CanAfford(price))
        {
            OnUpgradeCapacity?.Invoke(int.Parse(currentPlanet.GetID()), value);

            moneyProvider.SendMoney(-price);
        }
    }
}
