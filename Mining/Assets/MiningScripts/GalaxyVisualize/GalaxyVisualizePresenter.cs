using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyVisualizePresenter
{
    private GalaxyVisualizeModel model;
    private GalaxyVisualizeView view;

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
}
