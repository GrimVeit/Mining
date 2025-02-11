using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketTakeView : View
{
    [SerializeField] private RocketTake rocketTakePrefab;
    [SerializeField] private Transform content;

    private List<RocketTake> rocketsTake = new List<RocketTake>();

    public void SetOpenRocket(Rocket rocket)
    {
        var shopRocket = rocketsTake.FirstOrDefault(shopShip => shopShip.ID == int.Parse(rocket.GetID()));

        if (shopRocket == null)
        {
            shopRocket = Instantiate(rocketTakePrefab, content);
            shopRocket.SetData(rocket);
            shopRocket.OnBuyRocket += HandleBuyRocket;
            shopRocket.Initialize();

            rocketsTake.Add(shopRocket);
        }

        shopRocket.CloseBuy();
    }

    public void SetCloseRocket(Rocket rocket)
    {
        var shopRocket = rocketsTake.FirstOrDefault(shopShip => shopShip.ID == int.Parse(rocket.GetID()));

        if (shopRocket == null)
        {
            shopRocket = Instantiate(rocketTakePrefab, content);
            shopRocket.SetData(rocket);
            shopRocket.OnBuyRocket += HandleBuyRocket;
            shopRocket.Initialize();

            rocketsTake.Add(shopRocket);
        }

        shopRocket.OpenBuy();
    }

    public void Dispose()
    {
        rocketsTake.ForEach(shopRocket =>
        {
            shopRocket.OnBuyRocket -= HandleBuyRocket;
            shopRocket.Dispose();
        });

        rocketsTake.Clear();
    }

    #region Input

    public event Action<int> OnBuyRocket;

    private void HandleBuyRocket(int shipId)
    {
        OnBuyRocket?.Invoke(shipId);
    }

    #endregion
}
