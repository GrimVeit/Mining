using System;

public class ShopRocketPresenter
{
    private ShopRocketModel model;
    private ShopRocketView view;

    public ShopRocketPresenter(ShopRocketModel model, ShopRocketView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnBuyRocket += model.BuyRocket;

        model.OnSetOpenRocket += view.SetOpenRocket;
        model.OnSetCloseRocket += view.SetCloseRocket;
    }

    private void DeactivateEvents()
    {
        view.OnBuyRocket -= model.BuyRocket;

        model.OnSetOpenRocket -= view.SetOpenRocket;
        model.OnSetCloseRocket -= view.SetCloseRocket;
    }

    #region Input

    public event Action<int> OnBuyRocket
    {
        add { model.OnBuyRocket += value; }
        remove { model.OnBuyRocket -= value; }
    }

    public void SetOpenRocket(Rocket rocket)
    {
        model.SetOpenRocket(rocket);
    }

    public void SetCloseRocket(Rocket rocket)
    {
        model.SetCloseRocket(rocket);
    }

    #endregion
}
