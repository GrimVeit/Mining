using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyInfoPanel : MovePanel
{
    [SerializeField] private Button buttonClose;

    public override void Initialize()
    {
        base.Initialize();

        buttonClose.onClick.AddListener(HandleClickToClose);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonClose.onClick.RemoveListener(HandleClickToClose);
    }

    #region Input

    public event Action OnClose;

    private void HandleClickToClose()
    {
        OnClose?.Invoke();
    }

    #endregion
}
