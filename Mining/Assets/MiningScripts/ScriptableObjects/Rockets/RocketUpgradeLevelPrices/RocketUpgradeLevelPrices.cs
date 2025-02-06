using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket upgrade level prices")]
public class RocketUpgradeLevelPrices : ScriptableObject
{
    public List<RocketUpgradeLevelPrice> rocketUpgradeLevelPrices = new List<RocketUpgradeLevelPrice>();
}

[Serializable]
public class RocketUpgradeLevelPrice
{
    public int UpgradeLevelNumber;

    public List<RocketUpgradeSpeedPrice> rocketUpgradeSpeedPrices = new List<RocketUpgradeSpeedPrice>();
    public List<RocketUpgradeCapacityPrice> rocketUpgradeCapacityPrices = new List<RocketUpgradeCapacityPrice>();
}

[Serializable]
public class RocketUpgradeSpeedPrice
{
    public int rocketID;
    public int speedValue;
    public int price;
}

[Serializable]
public class RocketUpgradeCapacityPrice
{
    public int rocketID;
    public int capacityValue;
    public int price;
}
