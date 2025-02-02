using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopShipView : View
{
    [SerializeField] private ShopShip shopShipPrefab;
    [SerializeField] private Transform content;

    private List<ShopShip> shopShips = new List<ShopShip>();

    public void SetOpenShip(Ship ship)
    {
        var shopShip = shopShips.FirstOrDefault(shopShip => shopShip.ID == int.Parse(ship.GetID()));
        
        if (shopShip == null)
        {
            shopShip = Instantiate(shopShipPrefab, content);
            shopShip.SetData(ship);
            shopShip.OnBuyShip += HandleBuyShip;
            shopShip.Initialize();

            shopShips.Add(shopShip);
        }

        shopShip.OpenBuy();
    }

    public void SetCloseShip(Ship ship)
    {
        var shopShip = shopShips.FirstOrDefault(shopShip => shopShip.ID == int.Parse(ship.GetID()));

        if (shopShip == null)
        {
            shopShip = Instantiate(shopShipPrefab, content);
            shopShip.SetData(ship);
            shopShip.OnBuyShip += HandleBuyShip;
            shopShip.Initialize();

            shopShips.Add(shopShip);
        }

        shopShip.CloseBuy();
    }

    public void Dispose()
    {
        shopShips.ForEach(shopShip =>
        {
            shopShip.OnBuyShip -= HandleBuyShip;
            shopShip.Dispose();
        });

        shopShips.Clear();
    }

    #region Input

    public event Action<int> OnBuyShip;

    private void HandleBuyShip(int shipId)
    {
        OnBuyShip?.Invoke(shipId);
    }

    #endregion
}
