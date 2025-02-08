using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyInfoPanel : MovePanel
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private Button buttonOpenGalaxy;

    public override void Initialize()
    {
        base.Initialize();

        buttonClose.onClick.AddListener(HandleClickToClose);
        buttonOpenGalaxy.onClick.AddListener(HandleOpenGalaxy);
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonClose.onClick.RemoveListener(HandleClickToClose);
        buttonOpenGalaxy.onClick.RemoveListener(HandleOpenGalaxy);
    }

    #region Input

    public event Action OnClose;
    public event Action OnOpenGalaxy;

    private void HandleClickToClose()
    {
        OnClose?.Invoke();
    }

    private void HandleOpenGalaxy()
    {
        OnOpenGalaxy?.Invoke();
    }

    #endregion
}
