using System;
using UnityEngine;

public class SwipeClickAnimationModel
{
    public event Action<string> OnActivateAnimation;
    public event Action<string> OnDeactivateAnimation;

    public void ActivateAnimation(string id)
    {
        OnActivateAnimation?.Invoke(id);
    }

    public void DeactivateAnimation(string id)
    {
        OnDeactivateAnimation?.Invoke(id);
    }
}
