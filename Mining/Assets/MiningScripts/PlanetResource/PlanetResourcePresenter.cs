using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetResourcePresenter
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

    }

    public void Dispose()
    {

    }
}
