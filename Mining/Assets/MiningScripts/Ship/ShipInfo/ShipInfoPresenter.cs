using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfoPresenter
{
    private ShipInfoModel model;
    private ShipInfoView view;

    public ShipInfoPresenter(ShipInfoModel model, ShipInfoView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnBuyShip += model.BuyShip;
        view.OnPlayGame += model.PlayGame;

        model.OnSetOpenShip += view.SetOpenShip;
        model.OnSetCloseShip += view.SetCloseShip;
    }

    private void DeactivateEvents()
    {
        view.OnBuyShip -= model.BuyShip;
        view.OnPlayGame -= model.PlayGame;

        model.OnSetOpenShip -= view.SetOpenShip;
        model.OnSetCloseShip -= view.SetCloseShip;
    }

    #region Input

    public event Action<int> OnBuyShip
    {
        add { model.OnBuyShip += value; }
        remove { model.OnBuyShip -= value; }
    }

    public event Action OnPlayGame
    {
        add { model.OnPlayGame += value; }
        remove { model.OnPlayGame -= value; }
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
