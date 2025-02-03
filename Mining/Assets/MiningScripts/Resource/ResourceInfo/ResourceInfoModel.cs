using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfoModel
{
    public event Action<Resource> OnVisualizeResource;

    public void VisualizeResource(Resource resource)
    {
        OnVisualizeResource?.Invoke(resource);
    }
}
