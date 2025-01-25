using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeModel
{
    public event Action<string> OnActivateSwipe;
    public event Action<string> OnDeactivateSwipe;

    public event Action OnSwipeLeft;
    public event Action OnSwipeRight;
    public event Action OnSwipeUp;
    public event Action OnSwipeDown;

    private int deadZone = 0;

    public void Activate(string id)
    {
        OnActivateSwipe?.Invoke(id);
    }

    public void Deactivate(string id)
    {
        OnDeactivateSwipe?.Invoke(id);
    }

    public void CheckSwipeDirection(Vector2 dir)
    {
        if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
        {
            // UP
            if (dir.y > deadZone)
            {
                Debug.Log("SWIPE_UP");
                OnSwipeUp?.Invoke();
            }
            // DOWN
            if (dir.y < -deadZone)
            {
                Debug.Log("SWIPE_DOWN");
                OnSwipeDown?.Invoke();
            }
        }
        // LEFT / RIGHT
        else if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            // RIGHT
            if (dir.x > deadZone)
            {
                Debug.Log("SWIPE_RIGHT");
                OnSwipeRight?.Invoke();
            }
            // LEFT
            if (dir.x < -deadZone)
            {
                Debug.Log("SWIPE_LEFT");
                OnSwipeLeft?.Invoke();
            }
        }
    }
}
