using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreResourcePresenter
{
    private StoreResourceModel model;

    public StoreResourcePresenter(StoreResourceModel model)
    {
        this.model = model;
    }

    public void Initialize()
    {
        model.Initialize();
    }

    public void Dispose()
    {
        model.Dispose();
    }

    #region Input

    public event Action<Resource> OnVisualizeResource
    {
        add { model.OnVisualizeResource += value; }
        remove { model.OnVisualizeResource -= value; }
    }

    public event Action<Resource> OnSelectResource_Value
    {
        add { model.OnSelectResource_Value += value; }
        remove { model.OnSelectResource_Value -= value; }
    }

    public event Action<Resource> OnDeselectResource_Value
    {
        add { model.OnDeselectResource_Value += value; }
        remove { model.OnDeselectResource_Value -= value; }
    }

    public void SelectResource(ResourceType resourceType)
    {
        model.SelectResource(resourceType);
    }

    public void SaleSelectResource()
    {
        model.SaleSelectResource();
    }

    #endregion
}
