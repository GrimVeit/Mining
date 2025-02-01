using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInteractiveModel
{
    public event Action<ResourceType> OnSelectResource;
    public event Action<ResourceType> OnDeselectResource;

    public event Action OnClickToSaleResource;
    public event Action<ResourceType> OnChooseResource;

    public event Action<Resource> OnVisualizeResource;

    public void VisualizeResource(Resource resource)
    {
        OnVisualizeResource?.Invoke(resource);
    }

    public void ChooseResource(ResourceType resourceType)
    {
        OnChooseResource?.Invoke(resourceType);
    }

    public void SaleResource()
    {
        OnClickToSaleResource?.Invoke();
    }

    public void SelectResource(ResourceType resourceType)
    {
        OnSelectResource?.Invoke(resourceType);
    }

    public void DeselectResource(ResourceType resourceType)
    {
        OnDeselectResource?.Invoke(resourceType);
    }
}
