using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickView : View
{
    [SerializeField] private List<ClickZone> clickZones = new List<ClickZone>();

    public void Initialize()
    {
        clickZones.ForEach(data => data.OnClick += HandleClick);
    }

    public void Dispose()
    {
        clickZones.ForEach(data => data.OnClick -= HandleClick);
    }

    public void ActivateSwipe(string id)
    {
        clickZones.FirstOrDefault(data => data.GetID() == id).Activate();
    }

    public void DeactivateSwipe(string id)
    {
        clickZones.FirstOrDefault(data => data.GetID() == id).Deactivate();
    }

    #region Input

    public event Action OnClick;

    private void HandleClick()
    {
        OnClick?.Invoke();
    }

    #endregion
}
