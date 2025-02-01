using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInteractiveModel
{
    public event Action<ResourceType> OnSelectResource;
    public event Action<ResourceType> OnDeselectResource;
    public event Action<ResourceType> OnChooseResource;

    public event Action<Resource> OnVisualizeResource;

    private ResourcesGroup resources;

    public void SetResources(ResourcesGroup resources)
    {
        this.resources = resources;

        Debug.Log(resources.resources.Count);

        VisualizeResources();
    }

    private void VisualizeResources()
    {
        for (int i = 0; i < resources.resources.Count; i++)
        {
            OnVisualizeResource?.Invoke(resources.resources[i]);
        }
    }

    public void ChooseResource(ResourceType resourceType)
    {
        OnChooseResource?.Invoke(resourceType);
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
