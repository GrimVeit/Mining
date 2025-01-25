using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeClickDescriptionModel
{
    public event Action<string> OnActivateDescription;
    public event Action<string> OnDeactivateDescription;

    public void ActivateDescription(string id)
    {
        OnActivateDescription?.Invoke(id);
    }

    public void DeactivateDescription(string id)
    {
        OnDeactivateDescription?.Invoke(id);
    }
}
