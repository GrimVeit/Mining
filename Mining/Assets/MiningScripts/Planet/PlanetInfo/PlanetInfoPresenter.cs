using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoPresenter
{
    private PlanetInfoModel model;
    private PlanetInfoView view;

    public PlanetInfoPresenter(PlanetInfoModel model, PlanetInfoView view)
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
        model.OnSetPlanet += view.SetPlanet;
    }

    private void DeactivateEvents()
    {
        model.OnSetPlanet -= view.SetPlanet;
    }

    #region Input

    public void SetPlanet(Planet planet)
    {
        model.SetPlanet(planet);
    }

    #endregion
}
