using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwipeClickAnimation : MonoBehaviour, IIdentify
{
    public abstract void SetSwipe(SwipeClick swipe);
    public abstract void ActivateAnimation();
    public abstract void DeactivateAnimation();


    public abstract string GetID();
}
