using System;

public class ShopShipModel
{
    public event Action<int> OnBuyShip;

    public event Action<Ship> OnSetOpenShip;
    public event Action<Ship> OnSetCloseShip;

    public void SetOpenShip(Ship ship)
    {
        OnSetOpenShip?.Invoke(ship);
    }

    public void SetCloseShip(Ship ship)
    {
        OnSetCloseShip?.Invoke(ship);
    }

    public void BuyShip(int id)
    {
        OnBuyShip?.Invoke(id);
    }
}
