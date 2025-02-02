using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopShip : MonoBehaviour
{
    public int ID => id;

    [SerializeField] private TextMeshProUGUI textNameShip;
    [SerializeField] private Image imageShip;
    [SerializeField] private TextMeshProUGUI textLoadCapacity;
    [SerializeField] private TextMeshProUGUI textNumberBoats;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Button buttonBuyShip;

    private int id;

    public void Initialize()
    {
        buttonBuyShip.onClick.AddListener(()=> OnBuyShip?.Invoke(id));
    }

    public void SetData(Ship ship)
    {
        this.id = int.Parse(ship.GetID());

        textNameShip.text = ship.Name.ToUpper();
        imageShip.sprite = ship.Sprite;
        textLoadCapacity.text = ship.LoadCapacity.ToString();
        textNumberBoats.text = ship.CountBoats.ToString();
        textPrice.text = ship.Price.ToString();
    }

    public void Dispose()
    {
        buttonBuyShip.onClick.RemoveListener(() => OnBuyShip?.Invoke(id));
    }

    public void OpenBuy()
    {
        buttonBuyShip.gameObject.SetActive(false);
    }

    public void CloseBuy()
    {
        buttonBuyShip.gameObject.SetActive(true);
    }

    #region Input

    public event Action<int> OnBuyShip;

    #endregion
}
