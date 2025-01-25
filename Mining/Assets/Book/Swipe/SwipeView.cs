using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwipeView : View
{
    [SerializeField] private List<SwipeZone> swipeZones = new List<SwipeZone>();
    public void Initialize()
    {
        swipeZones.ForEach(data => data.OnGetDirection += HandleGetDirection);
    }

    public void Dispose()
    {
        swipeZones.ForEach(data => data.OnGetDirection -= HandleGetDirection);
    }

    public void ActivateSwipe(string id)
    {
        swipeZones.FirstOrDefault(data => data.GetID() == id).Activate();
    }

    public void DeactivateSwipe(string id)
    {
        swipeZones.FirstOrDefault(data => data.GetID() == id).Deactivate();
    }

    #region Input

    public event Action<Vector2> OnGetDirection;

    private void HandleGetDirection(Vector2 direction)
    {
        OnGetDirection?.Invoke(direction);
    }

    #endregion
}
