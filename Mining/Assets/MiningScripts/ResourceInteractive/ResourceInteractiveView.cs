using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceInteractiveView : View
{
    [SerializeField] private ResourceInteractive resourceInteractivePrefab;
    [SerializeField] private Transform transformResources;

    private List<ResourceInteractive> resourceInteractives = new List<ResourceInteractive>();

    public void VisualizeResource(Resource resource)
    {
        var interactive = Instantiate(resourceInteractivePrefab, transformResources);
        interactive.OnChooseResource += HandleChooseResource;
        interactive.SetData(resource);

        resourceInteractives.Add(interactive);
    }

    public void SelectResource(ResourceType resourceType)
    {
        resourceInteractives.FirstOrDefault(interactive => interactive.ResourceType == resourceType).SelectResource();
    }

    public void DeselectResource(ResourceType resourceType)
    {
        resourceInteractives.FirstOrDefault(interactive => interactive.ResourceType == resourceType).DeselectResource();
    }

    public void Dispose()
    {
        for (int i = 0; i < resourceInteractives.Count; i++)
        {
            resourceInteractives[i].OnChooseResource -= HandleChooseResource;
        }

        resourceInteractives.Clear();
    }

    #region Input

    public event Action<ResourceType> OnChooseResource;

    private void HandleChooseResource(ResourceType type)
    {
        OnChooseResource?.Invoke(type);
    }

    #endregion
}
