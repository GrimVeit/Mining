using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetResourcePresenter : IPlanetResourceProvider
{
    private PlanetResourceModel model;
    private PlanetResourceView view;

    public PlanetResourcePresenter(PlanetResourceModel model, PlanetResourceView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        model.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnVisualizePlanetResourceData += view.VisualizePlanetResourceData;
    }

    private void DeactivateEvents()
    {
        model.OnVisualizePlanetResourceData -= view.VisualizePlanetResourceData;
    }

    #region Input

    public IPlanetResource GetResource(int id)
    {
        return model.GetResource(id);
    }

    public void SetPlanets(Planets planets)
    {
        model.SetPlanets(planets);
    }

    public void SelectPlanet(Planet planet)
    {
        model.SelectPlanet(planet);
    }

    #endregion
}

public interface IPlanetResourceProvider
{
    IPlanetResource GetResource(int id);
}
