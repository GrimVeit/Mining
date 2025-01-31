using System;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoPanel : MovePanel
{
    [SerializeField] private Button buttonClose;

    public override void Initialize()
    {
        buttonClose.onClick.AddListener(()=> OnClickToClosePanel?.Invoke());
    }

    public override void Dispose()
    {
        buttonClose.onClick.RemoveListener(() => OnClickToClosePanel?.Invoke());
    }

    #region Input

    public event Action OnClickToClosePanel;

    #endregion
}
