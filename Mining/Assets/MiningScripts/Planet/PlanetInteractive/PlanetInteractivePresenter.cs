using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteractivePresenter
{
    private PlanetInteractiveModel model;
    private PlanetInteractiveView view;

    public PlanetInteractivePresenter(PlanetInteractiveModel model, PlanetInteractiveView view)
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
        view.OnChoosePlanet += model.ChoosePlanet;
        view.OnChooseSecondPlanet += model.ChooseSecondPlanet;

        model.OnVisualizePlanet += view.VisualizePlanet;
        model.OnUnlockPlanet += view.Unlock;
    }

    private void DeactivateEvents()
    {
        view.OnChoosePlanet -= model.ChoosePlanet;
        view.OnChooseSecondPlanet -= model.ChooseSecondPlanet;

        model.OnVisualizePlanet -= view.VisualizePlanet;
        model.OnUnlockPlanet -= view.Unlock;
    }

    #region Input

    public event Action<int> OnChoosePlanet_Value
    {
        add { model.OnChoosePlanet_Value += value; }
        remove { model.OnChoosePlanet_Value -= value; }
    }

    public event Action OnChoosePlanet
    {
        add { model.OnChoosePlanet += value; }
        remove { model.OnChoosePlanet -= value; }
    }

    public event Action OnChooseSecondPlanet
    {
        add { model.OnChooseSecondPlanet += value; }
        remove { model.OnChooseSecondPlanet -= value; }
    }

    public void SetPlanets(Planets planets)
    {
        model.SetPlanets(planets);
    }

    public void Unlock(Planet planet)
    {
        model.Unlock(int.Parse(planet.GetID()));
    }

    #endregion
}
