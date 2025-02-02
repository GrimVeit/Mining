using System;

public class ShopShipPresenter
{
    private ShopShipModel model;
    private ShopShipView view;

    public ShopShipPresenter(ShopShipModel model, ShopShipView view)
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
        view.OnBuyShip += model.BuyShip;

        model.OnSetOpenShip += view.SetOpenShip;
        model.OnSetCloseShip += view.SetCloseShip;
    }

    private void DeactivateEvents()
    {
        view.OnBuyShip -= model.BuyShip;

        model.OnSetOpenShip -= view.SetOpenShip;
        model.OnSetCloseShip -= view.SetCloseShip;
    }

    #region Input

    public event Action<int> OnBuyShipShip
    {
        add { model.OnBuyShip += value; }
        remove { model.OnBuyShip -= value; }
    }

    public void SetOpenShip(Ship ship)
    {
        model.SetOpenShip(ship);
    }

    public void SetCloseShip(Ship ship)
    {
        model.SetCloseShip(ship);
    }

    #endregion
}
