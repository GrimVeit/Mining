using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInteractiveView : View
{
    [SerializeField] private ResourceInteractive resourceInteractivePrefab;
    [SerializeField] private Transform transformResources;
    [SerializeField] private Button buttonSaleResource;

    private List<ResourceInteractive> resourceInteractives = new List<ResourceInteractive>();

    public void Initialize()
    {
        buttonSaleResource.onClick.AddListener(HandleSaleResource);
    }

    public void VisualizeResource(Resource resource)
    {
        var interactive = resourceInteractives.FirstOrDefault(interactive => interactive.ResourceType == resource.Type);

        if(interactive != null)
        {
            interactive.SetData(resource);
        }
        else
        {
            interactive = Instantiate(resourceInteractivePrefab, transformResources);
            interactive.OnChooseResource += HandleChooseResource;
            resourceInteractives.Add(interactive);
        }

        interactive.SetData(resource);
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

        buttonSaleResource.onClick.RemoveListener(HandleSaleResource);
    }

    #region Input

    public event Action OnSaleResource;
    public event Action<ResourceType> OnChooseResource;

    private void HandleChooseResource(ResourceType type)
    {
        OnChooseResource?.Invoke(type);
    }

    private void HandleSaleResource()
    {
        OnSaleResource?.Invoke();
    }

    #endregion
}
