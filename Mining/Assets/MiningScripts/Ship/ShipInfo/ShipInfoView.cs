using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfoView : View
{
    [SerializeField] private TextMeshProUGUI textShipName;
    [SerializeField] private TextMeshProUGUI textShipCapacity;
    [SerializeField] private TextMeshProUGUI textShipNumberBoats;
    [SerializeField] private Image imageShip;

    [Header("Close")]
    [SerializeField] private Button buttonBuy;
    [SerializeField] private TextMeshProUGUI textPrice;
    [Header("Open")]
    [SerializeField] private Button buttonPlay;

    private Ship currentShip;

    public void Initialize()
    {
        buttonBuy.onClick.AddListener(()=> OnBuyShip?.Invoke(int.Parse(currentShip.GetID())));
        buttonPlay.onClick.AddListener(()=> OnPlayGame?.Invoke());
    }

    public void Dispose()
    {
        buttonBuy.onClick.RemoveListener(() => OnBuyShip?.Invoke(int.Parse(currentShip.GetID())));
        buttonPlay.onClick.RemoveListener(() => OnPlayGame?.Invoke());
    }

    public void SetOpenShip(Ship ship)
    {
        this.currentShip = ship;

        textShipName.text = ship.Name;
        textShipCapacity.text = ship.LoadCapacity.ToString();
        textShipNumberBoats.text = ship.CountBoats.ToString();
        imageShip.sprite = ship.Sprite;

        buttonBuy.gameObject.SetActive(false);
        textPrice.gameObject.SetActive(false);
        textPrice.text = "";
        buttonPlay.gameObject.SetActive(true);
    }

    public void SetCloseShip(Ship ship)
    {
        this.currentShip = ship;

        textShipName.text = ship.Name;
        textShipCapacity.text = ship.LoadCapacity.ToString();
        textShipNumberBoats.text = ship.CountBoats.ToString();
        imageShip.sprite = ship.Sprite;

        buttonBuy.gameObject.SetActive(true);
        textPrice.gameObject.SetActive(true);
        textPrice.text = ship.Price.ToString();
        buttonPlay.gameObject.SetActive(false);
    }

    #region Input

    public event Action<int> OnBuyShip;
    public event Action OnPlayGame;

    #endregion
}
