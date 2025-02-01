using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfoPresenter
{
    private ResourceInfoModel model;
    private ResourceInfoView view;

    public ResourceInfoPresenter(ResourceInfoModel model, ResourceInfoView view)
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

    }

    private void DeactivateEvents()
    {

    }
}
