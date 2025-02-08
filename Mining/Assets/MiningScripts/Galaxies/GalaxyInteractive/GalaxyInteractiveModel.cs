using System;
using UnityEngine;

public class GalaxyInteractiveModel
{
    public event Action<int> OnLock;
    public event Action<int> OnUnlock;
    public event Action<int> OnUnlockSelect;

    public event Action<int> OnChooseGalaxy;

    public void ChooseGalaxy(int id)
    {
        OnChooseGalaxy?.Invoke(id);
    }

    public void Lock(int id)
    {
        OnLock?.Invoke(id);
    }

    public void Unlock(int id)
    {
        OnUnlock?.Invoke(id);
    }

    public void UnlockSelect(int id)
    {
        OnUnlockSelect?.Invoke(id);
    }
}
