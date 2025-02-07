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
        model.OnActivateRocket += view.ActivateRocket;
    }

    private void DeactivateEvents()
    {
        model.OnActivateRocket -= view.ActivateRocket;
    }

    #region Input

    public void SetPlanet(Planet planet)
    {
        model.ActivateRocket(planet);
    }

    #endregion
}
