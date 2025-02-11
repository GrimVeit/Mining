using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketTake : MonoBehaviour
{
    public int ID => int.Parse(CurrentRocket.GetID());

    [SerializeField] private TextMeshProUGUI textNameRocket;
    [SerializeField] private Image imageRocket;
    [SerializeField] private Button buttonTakeRocket;
    [SerializeField] private TextMeshProUGUI textRocketPrice;
    [SerializeField] private GameObject objectPurchased;

    public Rocket CurrentRocket { get; private set; }

    public void Initialize()
    {
        buttonTakeRocket.onClick.AddListener(() => OnBuyRocket?.Invoke(int.Parse(CurrentRocket.GetID())));
    }

    public void SetData(Rocket rocket)
    {
        this.CurrentRocket = rocket;

        textNameRocket.text = rocket.Name.ToUpper();
        imageRocket.sprite = rocket.Sprite;
    }

    public void Dispose()
    {
        buttonTakeRocket.onClick.RemoveListener(() => OnBuyRocket?.Invoke(int.Parse(CurrentRocket.GetID())));
    }

    public void OpenBuy()
    {
        buttonTakeRocket.gameObject.SetActive(true);
        textRocketPrice.text = CurrentRocket.Price.ToString();
        objectPurchased.SetActive(false);
    }

    public void CloseBuy()
    {
        buttonTakeRocket.gameObject.SetActive(false);
        objectPurchased.SetActive(true);
    }

    #region Input

    public event Action<int> OnBuyRocket;

    #endregion
}
