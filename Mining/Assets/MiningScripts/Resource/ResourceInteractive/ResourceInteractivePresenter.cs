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

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnChooseResource += model.ChooseResource;
        view.OnSaleResource += model.SaleResource;

        model.OnVisualizeResource += view.VisualizeResource;
        model.OnSelectResource += view.SelectResource;
        model.OnDeselectResource += view.DeselectResource;
    }

    private void DeactivateEvents()
    {
        view.OnChooseResource -= model.ChooseResource;
        view.OnSaleResource -= model.SaleResource;

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

    public event Action OnClickToSaleResource
    {
        add { model.OnClickToSaleResource += value; }
        remove { model.OnClickToSaleResource -= value; }
    }

    public void VisualizeResource(Resource resource)
    {
        model.VisualizeResource(resource);
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
