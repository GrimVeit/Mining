using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopRocketView : View
{
    [SerializeField] private ShopRocket shopRocketPrefab;
    [SerializeField] private Transform content;

    private List<ShopRocket> shopRockets = new List<ShopRocket>();

    public void SetOpenRocket(Rocket rocket)
    {
        var shopRocket = shopRockets.FirstOrDefault(shopShip => shopShip.ID == int.Parse(rocket.GetID()));

        if (shopRocket == null)
        {
            shopRocket = Instantiate(shopRocketPrefab, content);
            shopRocket.SetData(rocket);
            shopRocket.OnBuyRocket += HandleBuyRocket;
            shopRocket.Initialize();

            shopRockets.Add(shopRocket);
        }

        shopRocket.OpenBuy();
    }

    public void SetCloseRocket(Rocket rocket)
    {
        var shopRocket = shopRockets.FirstOrDefault(shopShip => shopShip.ID == int.Parse(rocket.GetID()));

        if (shopRocket == null)
        {
            shopRocket = Instantiate(shopRocketPrefab, content);
            shopRocket.SetData(rocket);
            shopRocket.OnBuyRocket += HandleBuyRocket;
            shopRocket.Initialize();

            shopRockets.Add(shopRocket);
        }

        shopRocket.CloseBuy();
    }

    public void Dispose()
    {
        shopRockets.ForEach(shopRocket =>
        {
            shopRocket.OnBuyRocket -= HandleBuyRocket;
            shopRocket.Dispose();
        });

        shopRockets.Clear();
    }

    #region Input

    public event Action<int> OnBuyRocket;

    private void HandleBuyRocket(int shipId)
    {
        OnBuyRocket?.Invoke(shipId);
    }

    #endregion
}
