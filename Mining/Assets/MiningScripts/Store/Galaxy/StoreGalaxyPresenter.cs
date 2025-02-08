using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGalaxyPresenter
{
    private StoreGalaxyModel model;

    public StoreGalaxyPresenter(StoreGalaxyModel model)
    {
        this.model = model;
    }

    public void Initialize()
    {
        model.Initialize();
    }

    public void Dispose()
    {
        model.Dispose();
    }

    #region Input

    public event Action<Galaxy> OnSelectOpenGalaxy_Value
    {
        add { model.OnSelectOpenGalaxy_Value += value; }
        remove { model.OnSelectOpenGalaxy_Value -= value; }
    }

    public event Action<Galaxy> OnSelectCloseGalaxy_Value
    {
        add { model.OnSelectCloseGalaxy_Value += value; }
        remove { model.OnSelectCloseGalaxy_Value -= value; }
    }

    public event Action<Galaxy> OnDeselectOpenGalaxy_Value
    {
        add { model.OnDeselectOpenGalaxy_Value += value; }
        remove { model.OnDeselectOpenGalaxy_Value -= value; }
    }

    public event Action<Galaxy> OnDeselectCloseGalaxy_Value
    {
        add { model.OnDeselectCloseGalaxy_Value += value; }
        remove { model.OnDeselectCloseGalaxy_Value -= value; }
    }




    public event Action OnSelectGalaxy
    {
        add { model.OnSelectGalaxy += value; }
        remove { model.OnSelectGalaxy -= value; }
    }

    public event Action OnDeselectGalaxy
    {
        add { model.OnDeselectGalaxy += value; }
        remove { model.OnDeselectGalaxy -= value; }
    }




    public event Action<Galaxy> OnSelectGalaxy_Value
    {
        add { model.OnSelectGalaxy_Value += value; }
        remove { model.OnSelectGalaxy_Value -= value; }
    }


    public event Action<int> OnOpenGalaxy
    {
        add { model.OnOpenGalaxy += value; }
        remove { model.OnOpenGalaxy -= value; }
    }

    public event Action<int> OnCloseGalaxy
    {
        add { model.OnCloseGalaxy += value; }
        remove { model.OnCloseGalaxy -= value; }
    }


    public void SelectGalaxy(int id)
    {
        model.SelectGalaxy(id);
    }

    public void UnlockGalaxy(int id)
    {
        model.UnlockGalaxy(id);
    }

    #endregion
}
