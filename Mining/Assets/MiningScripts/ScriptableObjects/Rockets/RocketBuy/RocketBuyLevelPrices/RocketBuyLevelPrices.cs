using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket Prices")]
public class RocketBuyLevelPrices : ScriptableObject
{
    public List<RocketBuyLevelPrice> rocketBuyLevelPrices= new List<RocketBuyLevelPrice>();
}

[Serializable]
public class RocketBuyLevelPrice
{
    public int BuyLevelNumber;

    public List<RocketBuyPrice> rocketBuyPrices = new List<RocketBuyPrice>();
}

[Serializable]
public class RocketBuyPrice
{
    public int rocketID;
    public int price;
}
