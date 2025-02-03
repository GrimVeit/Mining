using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetBuyView : View
{
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Button buttonBuyPlanet;
    [SerializeField] private GameObject objectPlanetBuyDisplay;

    public void Initialize()
    {
        buttonBuyPlanet.onClick.AddListener(HandleClickToBuyPlanetButton);
    }

    public void Dispose()
    {
        buttonBuyPlanet.onClick.RemoveListener(HandleClickToBuyPlanetButton);
    }

    public void ActivatePlanetBuyDisplay()
    {
        objectPlanetBuyDisplay.SetActive(true);
    }

    public void DeactivatePlanetBuyDisplay()
    {
        objectPlanetBuyDisplay.SetActive(false);
    }

    public void SetPlanetData(Planet planet)
    {
        textPrice.text = planet.Price.ToString();
    }

    #region Input

    public event Action OnBuyPlanet;

    private void HandleClickToBuyPlanetButton()
    {
        OnBuyPlanet?.Invoke();
    }

    #endregion
}
