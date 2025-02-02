using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopRocket : MonoBehaviour
{
    public int ID => id;

    [SerializeField] private TextMeshProUGUI textNameRocket;
    [SerializeField] private Image imageRocket;
    [SerializeField] private TextMeshProUGUI textLoadCapacity;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Button buttonBuyRocket;

    private int id;

    public void Initialize()
    {
        buttonBuyRocket.onClick.AddListener(() => OnBuyRocket?.Invoke(id));
    }

    public void SetData(Rocket rocket)
    {
        this.id = int.Parse(rocket.GetID());

        textNameRocket.text = rocket.Name.ToUpper();
        imageRocket.sprite = rocket.Sprite;
        textLoadCapacity.text = rocket.BaseLoadCapacity.ToString();
        textPrice.text = rocket.Price.ToString();
    }

    public void Dispose()
    {
        buttonBuyRocket.onClick.RemoveListener(() => OnBuyRocket?.Invoke(id));
    }

    public void OpenBuy()
    {
        buttonBuyRocket.gameObject.SetActive(false);
    }

    public void CloseBuy()
    {
        buttonBuyRocket.gameObject.SetActive(true);
    }

    #region Input

    public event Action<int> OnBuyRocket;

    #endregion
}
