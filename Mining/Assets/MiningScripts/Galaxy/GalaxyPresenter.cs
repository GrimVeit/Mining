using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPresenter
{
    private GalaxyModel model;
    private GalaxyView view;

    public GalaxyPresenter(GalaxyModel model, GalaxyView view)
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
