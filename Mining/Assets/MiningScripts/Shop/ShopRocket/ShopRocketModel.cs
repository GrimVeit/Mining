using System;

public class ShopRocketModel
{
    public event Action<int> OnBuyRocket;

    public event Action<Rocket> OnSetOpenRocket;
    public event Action<Rocket> OnSetCloseRocket;

    public void SetOpenRocket(Rocket rocket)
    {
        OnSetOpenRocket?.Invoke(rocket);
    }

    public void SetCloseRocket(Rocket rocket)
    {
        OnSetCloseRocket?.Invoke(rocket);
    }

    public void BuyRocket(int id)
    {
        OnBuyRocket?.Invoke(id);
    }
}
