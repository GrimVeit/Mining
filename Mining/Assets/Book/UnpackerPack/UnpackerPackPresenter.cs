using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerPackPresenter
{
    private UnpackerPackModel model;
    private UnpackerPackView view;

    public UnpackerPackPresenter(UnpackerPackModel model, UnpackerPackView view)
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
        model.OnSpawnPack += view.SpawnPack;
        model.OnMovePackToOpen += view.MovePackToOpen;
        model.OnMovePackToClose_Left += view.MovePackToClose_Left;
        model.OnMovePackToClose_Right += view.MovePackToClose_Right;
    }

    private void DeactivateEvents()
    {
        model.OnSpawnPack -= view.SpawnPack;
        model.OnMovePackToOpen -= view.MovePackToOpen;
        model.OnMovePackToClose_Left -= view.MovePackToClose_Left;
        model.OnMovePackToClose_Right -= view.MovePackToClose_Right;
    }

    #region Input


    public event Action OnStartClosePack
    {
        add { view.OnStartClosePack += value; }
        remove { view.OnStartClosePack -= value; }
    }

    public event Action OnOpenPack
    {
        add { view.OnOpenPack += value; }
        remove { view.OnOpenPack -= value; }
    }

    public event Action OnClosePack
    {
        add { view.OnClosePack += value; }
        remove { view.OnClosePack -= value; }
    }

    public void SpawnPack(Pack pack)
    {
        model.SpawnPack(pack);
    }

    public void MovePackToOpen()
    {
        model.MovePackToOpen();
    }

    public void MovePackToClose_Left()
    {
        model.MovePackToClose_Left();
    }

    public void MovePackToClose_Right()
    {
        model.MovePackToClose_Right();
    }

    #endregion
}
