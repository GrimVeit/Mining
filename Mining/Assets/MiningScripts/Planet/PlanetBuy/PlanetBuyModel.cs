using System;
using UnityEngine;

public class PlanetBuyModel
{
    public event Action<int> OnBuyPlanet;

    public event Action OnActivate;
    public event Action OnDeactivate;
    public event Action<Planet> OnSetPlanet;

    private Planet currentPlanet;

    private IMoneyProvider moneyProvider;

    public PlanetBuyModel(IMoneyProvider moneyProvider)
    {
        this.moneyProvider = moneyProvider;
    }

    public void SetClosePlanet(Planet planet)
    {
        this.currentPlanet = planet;

        OnSetPlanet?.Invoke(currentPlanet);

        OnActivate?.Invoke();
    }

    public void SetOpenPlanet()
    {
        OnDeactivate?.Invoke();
    }

    public void BuyPlanet()
    {
        if (moneyProvider.CanAfford(currentPlanet.Price))
        {
            moneyProvider.SendMoney(-currentPlanet.Price);

            OnBuyPlanet?.Invoke(int.Parse(currentPlanet.GetID()));
        }
    }
}
