using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTransferPresenter
{
    private RocketTransferModel model;
    private RocketTransferView view;

    public RocketTransferPresenter(RocketTransferModel model, RocketTransferView view)
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
        view.OnSendResources += model.SendResources;

        model.OnSpawnRocket += view.SpawnRocket;
        model.OnReturnRocketToShip += view.ReturnRocketToShip;
    }

    private void DeactivateEvents()
    {
        view.OnSendResources -= model.SendResources;

        model.OnSpawnRocket -= view.SpawnRocket;
        model.OnReturnRocketToShip -= view.ReturnRocketToShip;
    }

    #region Input

    public event Action<ResourceType, int> OnSendResources
    {
        add { model.OnSendResources += value; }
        remove { model.OnSendResources -= value; }
    }

    public void SetPlanet(Planet planet)
    {
        model.SpawnRocket(planet);
    }

    public void ReturnRocketToShip(Planet planet)
    {
        model.ReturnRocketToShip(planet);
    }

    #endregion
}
