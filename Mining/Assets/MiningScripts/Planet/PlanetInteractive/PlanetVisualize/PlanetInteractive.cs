using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetInteractive : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private protected Image imagePlanet;
    [SerializeField] private protected GameObject objectShadow;
    [SerializeField] private TextMeshProUGUI textPrice;

    public int ID => id;
    public event Action<int> OnClickToPlanet;

    private int id;

    public void Initialize(int id)
    {
        this.id = id;
    }

    public void SetData(Sprite sprite, int price)
    {
        imagePlanet.sprite = sprite;
        textPrice.text = price.ToString();
    }

    public void Unlock()
    {
        objectShadow.SetActive(false);
    }

    public void Dispose()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(id);

        OnClickToPlanet?.Invoke(id);
    }
}
