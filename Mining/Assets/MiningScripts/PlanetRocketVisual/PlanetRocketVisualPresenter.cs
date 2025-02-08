using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetRocketVisualPresenter
{
    private PlanetRocketVisualModel model;
    private PlanetRocketVisualView view;

    public PlanetRocketVisualPresenter(PlanetRocketVisualModel model, PlanetRocketVisualView view)
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
        model.OnSelectLowPlanet += view.SelectLow;
        model.OnSelectMiddlePlanet += view.SelectMiddle;
        model.OnSelectHighPlanet += view.SelectHigh;
        model.OnSelectShip += view.SelectShip;
        model.OnSelectDefault += view.SelectDefault;
    }

    private void DeactivateEvents()
    {
        model.OnSelectLowPlanet -= view.SelectLow;
        model.OnSelectMiddlePlanet -= view.SelectMiddle;
        model.OnSelectHighPlanet -= view.SelectHigh;
        model.OnSelectShip -= view.SelectShip;
        model.OnSelectDefault -= view.SelectDefault;
    }

    #region Input

    public void Select(Planet planet)
    {
        model.Select(planet.interactivePosition.PositionID, planet.PlanetType);
    }

    public void SelectShip()
    {
        model.SelectShip();
    }

    public void SelectDefault()
    {
        model.SelectDefault();
    }

    #endregion
}
