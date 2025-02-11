using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShipTakeView : View
{
    [SerializeField] private TakeShip takeShipPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private Image imageShip;

    private List<TakeShip> takeShips = new List<TakeShip>();

    public void SetShip(Ship ship)
    {
        var shopShip = takeShips.FirstOrDefault(shopShip => shopShip.ID == int.Parse(ship.GetID()));

        if (shopShip == null)
        {
            shopShip = Instantiate(takeShipPrefab, content);
            shopShip.SetData(ship);
            shopShip.OnTakeShip += HandleTakeShip;
            shopShip.Initialize();

            takeShips.Add(shopShip);
        }
    }

    public void Dispose()
    {
        takeShips.ForEach(shopShip =>
        {
            shopShip.OnTakeShip -= HandleTakeShip;
            shopShip.Dispose();
        });

        takeShips.Clear();
    }

    public void SelectShip(int id)
    {
        var ship = takeShips.FirstOrDefault(data => data.ID == id);
        ship.SelectShip();
        imageShip.sprite = ship.CurrentShip.Sprite; 
    }

    public void DeselectShip(int id)
    {
        takeShips.FirstOrDefault(data => data.ID == id).UnselectShip();
    }

    #region Input

    public event Action<int> OnTakeShip;

    private void HandleTakeShip(int shipId)
    {
        OnTakeShip?.Invoke(shipId);
    }

    #endregion
}
