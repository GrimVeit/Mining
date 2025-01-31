using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetInteractive : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private protected Image imagePlanet;

    public int ID => id;
    public event Action<int> OnClickToPlanet;

    private int id;

    public void Initialize(int id)
    {
        this.id = id;
    }

    public void SetData(Sprite sprite)
    {
        imagePlanet.sprite = sprite;
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
