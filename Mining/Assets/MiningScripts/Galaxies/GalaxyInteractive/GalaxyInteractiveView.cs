using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GalaxyInteractiveView : View
{
    [SerializeField] private List<GalaxyInteractive> galaxyVisualizes = new List<GalaxyInteractive>();

    public void Initialize()
    {
        for (int i = 0; i < galaxyVisualizes.Count; i++)
        {
            galaxyVisualizes[i].OnChooseGalaxy += HandleChooseGalaxy;
            galaxyVisualizes[i].Initialize(i);
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < galaxyVisualizes.Count; i++)
        {
            galaxyVisualizes[i].OnChooseGalaxy -= HandleChooseGalaxy;
            galaxyVisualizes[i].Dispose();
        }
    }

    public void Lock(int id)
    {
        galaxyVisualizes.FirstOrDefault(data => data.ID == id).Lock();
    }

    public void Unlock(int id)
    {
        galaxyVisualizes.FirstOrDefault(data => data.ID == id).Unlock();
    }

    public void LockSelect(int id)
    {
        galaxyVisualizes.FirstOrDefault(data => data.ID == id).LockSelect();
    }

    #region Input

    public event Action<int> OnChooseGalaxy;

    private void HandleChooseGalaxy(int id)
    {
        OnChooseGalaxy?.Invoke(id);
    }

    #endregion
}
