using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources")] 
public class ResourcesGroup : ScriptableObject
{
    public List<Resource> resources = new List<Resource>();

    public Resource GetResourceByType(ResourceType resourceType)
    {
        return resources.FirstOrDefault(resource => resource.Type == resourceType);
    }
}
