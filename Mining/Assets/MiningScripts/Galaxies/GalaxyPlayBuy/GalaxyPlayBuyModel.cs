using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPlayBuyModel
{
    public event Action<int> OnBuyGalaxy;

    public event Action OnSetOpenGalaxy;
    public event Action<int> OnSetCloseGalaxy;

    private Galaxy currentGalaxy;

    private IMoneyProvider moneyProvider;

    public GalaxyPlayBuyModel(IMoneyProvider moneyProvider)
    {
        this.moneyProvider = moneyProvider;
    }

    public void SetOpenGalaxy(Galaxy galaxy)
    {
        currentGalaxy = galaxy;

        OnSetOpenGalaxy?.Invoke();
    }

    public void SetCloseGalaxy(Galaxy galaxy)
    {
        currentGalaxy = galaxy;

        OnSetCloseGalaxy?.Invoke(currentGalaxy.GetPrice());
    }

    public void BuyGalaxy()
    {
        if (moneyProvider.CanAfford(currentGalaxy.GetPrice()))
        {
            moneyProvider.SendMoney(-currentGalaxy.GetPrice());
            OnBuyGalaxy?.Invoke(currentGalaxy.GalaxyData.Number);
        }
    }
}
