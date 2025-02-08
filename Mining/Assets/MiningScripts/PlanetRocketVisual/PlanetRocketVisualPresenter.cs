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
        model.OnSelect += view.MoveTo;
    }

    private void DeactivateEvents()
    {
        model.OnSelect -= view.MoveTo;
    }

    #region Input

    public void Select(Planet planet)
    {
        model.Select(planet.interactivePosition.PositionID);
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
