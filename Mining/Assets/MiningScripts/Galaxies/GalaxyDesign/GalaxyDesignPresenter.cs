using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyDesignPresenter
{
    private GalaxyDesignModel model;
    private GalaxyDesignView view;

    public GalaxyDesignPresenter(GalaxyDesignModel model, GalaxyDesignView view)
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
    }

    private void ActivateEvents()
    {
        model.OnSetGalaxy += view.SetGalaxy;
    }

    private void DeactivateEvents()
    {
        model.OnSetGalaxy -= view.SetGalaxy;
    }

    #region Input

    public void SetGalaxy(Galaxy galaxy)
    {
        model.SetGalaxy(galaxy);
    }

    #endregion
}
