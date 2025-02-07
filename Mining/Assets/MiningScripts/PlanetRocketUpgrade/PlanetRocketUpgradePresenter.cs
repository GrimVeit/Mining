using System;
using UnityEngine;

public class PlanetRocketUpgradePresenter
{
    private PlanetRocketUpgradeModel model;
    private PlanetRocketUpgradeView view;

    public PlanetRocketUpgradePresenter(PlanetRocketUpgradeModel model, PlanetRocketUpgradeView view)
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
        view.OnSelectCapacity += model.SelectCapacity;
        view.OnSelectSpeed += model.SelectSpeed;
        view.OnClickToUpgradeCapacity += model.UpgradeCapacity;
        view.OnClickToUpgradeSpeed += model.UpgradeSpeed;

        model.OnActivateDisplay += view.ActivateRocketUpgradeDisplay;
        model.OnDeactivateDisplay += view.DeactivateRocketUpgradeDisplay;
        model.OnAllDeactivated += view.AllDeactivate;

        model.OnVisualizeRocketData += view.SetRocketPlanetData;

        model.OnActivateButtonSpeed += view.ActivateSpeedButton;
        model.OnDeactivateButtonSpeed += view.DeactivateSpeedButton;
        model.OnActivateButtonCapacity += view.ActivateCapacityButton;
        model.OnDeactivateButtonCapacity += view.DeactivateCapacityButton;

        model.OnSelectCapacityInteractive += view.SelectCapacityInteractive;
        model.OnSelectSpeedInteractive += view.SelectSpeedInteractive;
    }

    private void DeactivateEvents()
    {
        view.OnSelectCapacity -= model.SelectCapacity;
        view.OnSelectSpeed -= model.SelectSpeed;
        view.OnClickToUpgradeCapacity -= model.UpgradeCapacity;
        view.OnClickToUpgradeSpeed -= model.UpgradeSpeed;

        model.OnActivateDisplay -= view.ActivateRocketUpgradeDisplay;
        model.OnDeactivateDisplay -= view.DeactivateRocketUpgradeDisplay;
        model.OnAllDeactivated -= view.AllDeactivate;

        model.OnVisualizeRocketData -= view.SetRocketPlanetData;

        model.OnActivateButtonSpeed -= view.ActivateSpeedButton;
        model.OnDeactivateButtonSpeed -= view.DeactivateSpeedButton;
        model.OnActivateButtonCapacity -= view.ActivateCapacityButton;
        model.OnDeactivateButtonCapacity -= view.DeactivateCapacityButton;

        model.OnSelectCapacityInteractive -= view.SelectCapacityInteractive;
        model.OnSelectSpeedInteractive -= view.SelectSpeedInteractive;
    }

    #region Input

    public event Action<int, float> OnUpgradeSpeed
    {
        add { model.OnUpgradeSpeed += value; }
        remove { model.OnUpgradeSpeed -= value; }
    }

    public event Action<int, int> OnUpgradeCapacity
    {
        add { model.OnUpgradeCapacity += value; }
        remove { model.OnUpgradeCapacity -= value; }
    }

    public void SetRocketPlanet(Planet planet)
    {
        model.SetRocketPlanet(planet);
    }

    public void SetNoneRocketPlanet(Planet planet)
    {
        model.SetNoneRocket();
    }

    #endregion
}
