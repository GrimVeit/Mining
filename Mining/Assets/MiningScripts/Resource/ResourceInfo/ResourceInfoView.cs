using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceInfoView : View
{
    [SerializeField] private ResourceInfo resourceInfoPrefab;
    [SerializeField] private Transform transformResources;

    private List<ResourceInfo> resourceInfos = new List<ResourceInfo>();

    public void Initialize()
    {

    }

    public void VisualizeResource(Resource resource)
    {
        var interactive = resourceInfos.FirstOrDefault(interactive => interactive.ResourceType == resource.Type);

        if (interactive == null)
        {
            interactive = Instantiate(resourceInfoPrefab, transformResources);
            resourceInfos.Add(interactive);
        }

        interactive.SetData(resource);
    }

    public void Dispose()
    {
        resourceInfos.Clear();
    }
}
