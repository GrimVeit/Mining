using System;

public class ShipInfoModel
{
    public event Action<Ship> OnSetOpenShip;
    public event Action<Ship> OnSetCloseShip;

    public event Action<int> OnBuyShip;
    public event Action OnPlayGame;

    public void SetOpenShip(Ship ship)
    {
        OnSetOpenShip?.Invoke(ship);
    }

    public void SetCloseShip(Ship ship)
    {
        OnSetCloseShip?.Invoke(ship);
    }



    public void BuyShip(int shipId)
    {
        OnBuyShip?.Invoke(shipId);
    }

    public void PlayGame()
    {
        OnPlayGame?.Invoke();
    }
}
