using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class GalaxyVisualizePresenter
{
    private GalaxyVisualizeModel model;
    private GalaxyVisualizeView view;

    public GalaxyVisualizePresenter(GalaxyVisualizeModel model, GalaxyVisualizeView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        view.OnChooseGalaxy += model.ChooseGalaxy;

        model.OnLock += view.Lock;
        model.OnUnlock += view.Unlock;
        model.OnUnlockSelect += view.LockSelect;
    }

    private void DeactivateEvents()
    {
        view.OnChooseGalaxy -= model.ChooseGalaxy;

        model.OnLock -= view.Lock;
        model.OnUnlock -= view.Unlock;
        model.OnUnlockSelect -= view.LockSelect;
    }

    #region Input

    public event Action<int> OnChooseGalaxy
    {
        add { model.OnChooseGalaxy += value; }
        remove { model.OnChooseGalaxy -= value; }
    }

    public void Lock(int id)
    {
        model.Lock(id);
    }

    public void Unlock(int id)
    {
        model.Unlock(id);
    }

    public void UnlockSelect(int id)
    {
        model.UnlockSelect(id);
    }

    public void Unlock(Galaxy galaxy)
    {
        model.Unlock(int.Parse(galaxy.GetID()));
    }

    public void Lock(Galaxy galaxy)
    {
        model.Lock(int.Parse(galaxy.GetID()));
    }

    public void UnlockSelect(Galaxy galaxy)
    {
        model.UnlockSelect(int.Parse(galaxy.GetID()));
    }

    #endregion
}
