using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInteractivePresenter
{
    private ResourceInteractiveModel model;
    private ResourceInteractiveView view;

    public ResourceInteractivePresenter(ResourceInteractiveModel model, ResourceInteractiveView view)
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
        view.OnChooseResource += model.ChooseResource;

        model.OnVisualizeResource += view.VisualizeResource;
        model.OnSelectResource += view.SelectResource;
        model.OnDeselectResource += view.DeselectResource;
    }

    private void DeactivateEvents()
    {
        view.OnChooseResource -= model.ChooseResource;

        model.OnVisualizeResource -= view.VisualizeResource;
        model.OnSelectResource -= view.SelectResource;
        model.OnDeselectResource -= view.DeselectResource;
    }

    #region Input

    public event Action<ResourceType> OnChooseResource
    {
        add { model.OnChooseResource += value; }
        remove { model.OnChooseResource -= value; }
    }

    public void SetResources(ResourcesGroup resourceGroup)
    {
        model.SetResources(resourceGroup);
    }

    public void SelectResource(Resource resource)
    {
        model.SelectResource(resource.Type);
    }

    public void DeselectResource(Resource resource)
    {
        model.DeselectResource(resource.Type);
    }

    #endregion
}
