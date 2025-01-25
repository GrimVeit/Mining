using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwipeClickDescription : MonoBehaviour, IIdentify
{
    public abstract void ActivateDescription();

    public abstract void DeactivateDescription();

    public abstract string GetID();
}
