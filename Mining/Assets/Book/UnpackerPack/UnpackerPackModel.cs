using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerPackModel
{
    public event Action OnMovePackToClose_Left;
    public event Action OnMovePackToClose_Right;

    public event Action<CardInfo> OnSpawnDuplicateCard;
    public event Action<CardInfo> OnSpawnNewCard;

    public event Action<Pack> OnSpawnPack;
    public event Action OnMovePackToOpen;

    public void SpawnPack(Pack pack)
    {
        OnSpawnPack?.Invoke(pack);
    }

    public void MovePackToOpen()
    {
        OnMovePackToOpen?.Invoke();
    }

    public void MovePackToClose_Left()
    {
        OnMovePackToClose_Left?.Invoke();
    }

    public void MovePackToClose_Right()
    {
        OnMovePackToClose_Right?.Invoke();
    }
}
