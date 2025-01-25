using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyBuyDisplay : MonoBehaviour
{
    [SerializeField] private Button buttonBuy;
    [SerializeField] private GameObject objectPrice;
    [SerializeField] private TextMeshProUGUI textPrice;

    public void Initialize()
    {
        buttonBuy.onClick.AddListener(() => OnClickToBuy?.Invoke());
    }

    public void Dispose()
    {
        buttonBuy.onClick.RemoveListener(() => OnClickToBuy?.Invoke());
    }

    public void OpenDisplay()
    {
        objectPrice.SetActive(true);
        buttonBuy.enabled = true;
        buttonBuy.gameObject.SetActive(true);
    }

    public void CloseDisplay()
    {
        objectPrice.SetActive(false);
        buttonBuy.enabled = false;
        buttonBuy.gameObject.SetActive(false);
    }

    public void SetPrice(int price)
    {
        textPrice.text = price.ToString();
    }

    #region Input

    public event Action OnClickToBuy;

    #endregion
}
