using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyVisualModel
{
    public event Action<int> OnSelect;
    public event Action OnSelectDefault;

    public void Select(int id)
    {
        OnSelect?.Invoke(id);
    }

    public void SelectDefault()
    {
        OnSelectDefault?.Invoke();
    }
}
