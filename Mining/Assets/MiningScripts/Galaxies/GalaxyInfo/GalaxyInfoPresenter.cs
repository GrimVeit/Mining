using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyInfoPresenter
{
    private GalaxyInfoModel model;
    private GalaxyInfoView view;

    public GalaxyInfoPresenter(GalaxyInfoModel model, GalaxyInfoView view)
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
        model.OnSetGalaxy += view.SetGalaxyInfo;
    }

    private void DeactivateEvents()
    {
        model.OnSetGalaxy -= view.SetGalaxyInfo;
    }

    #region Input

    public void SetGalaxy(Galaxy galaxy)
    {
        model.SetGalaxy(galaxy);
    }

    #endregion
}
