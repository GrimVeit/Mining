using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPlayBuyPresenter
{
    private GalaxyPlayBuyModel model;
    private GalaxyPlayBuyView view;

    public GalaxyPlayBuyPresenter(GalaxyPlayBuyModel model, GalaxyPlayBuyView view)
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
        view.OnClickToBuy += model.BuyGalaxy;
        //view.OnClickToPlay += model.

        model.OnSetCloseGalaxy += view.OpenBuyDisplay;
        model.OnSetOpenGalaxy += view.OpenPlayDisplay;
    }

    private void DeactivateEvents()
    {
        model.OnSetCloseGalaxy -= view.OpenBuyDisplay;
        model.OnSetOpenGalaxy -= view.OpenPlayDisplay;
    }

    #region Input

    public event Action<int> OnBuyGalaxy
    {
        add { model.OnBuyGalaxy += value; }
        remove { model.OnBuyGalaxy -= value; }
    }

    public void SetOpenGalaxy(Galaxy galaxy)
    {
        model.SetOpenGalaxy(galaxy);
    }

    public void SetCloseGalaxy(Galaxy galaxy)
    {
        model.SetCloseGalaxy(galaxy);
    }

    #endregion
}
