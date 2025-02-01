using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayButtonsPanel : MovePanel
{
    [SerializeField] private Button buttonResourceDescription;
    [SerializeField] private Button buttonResourceSale;
    [SerializeField] private Button buttonPlanetInfo;
    [SerializeField] private Button buttonShop;

    public override void Initialize()
    {
        buttonPlanetInfo.onClick.AddListener(() => OnClickToOpen_PlanetInfo?.Invoke());
        buttonResourceDescription.onClick.AddListener(()=> OnClickToOpen_ResourceDescription?.Invoke());
        buttonResourceSale.onClick.AddListener(() => OnClickToOpen_ResourceSale?.Invoke());
        buttonShop.onClick.AddListener(()=> OnClickToOpen_Shop?.Invoke());
    }

    public override void Dispose()
    {
        buttonPlanetInfo.onClick.RemoveListener(() => OnClickToOpen_PlanetInfo?.Invoke());
        buttonResourceDescription.onClick.RemoveListener(() => OnClickToOpen_ResourceDescription?.Invoke());
        buttonResourceSale.onClick.RemoveListener(() => OnClickToOpen_ResourceSale?.Invoke());
        buttonShop.onClick.RemoveListener(() => OnClickToOpen_Shop?.Invoke());
    }

    #region Input

    public event Action OnClickToOpen_PlanetInfo;
    public event Action OnClickToOpen_ResourceDescription;
    public event Action OnClickToOpen_ResourceSale;
    public event Action OnClickToOpen_Shop;

    #endregion
}
