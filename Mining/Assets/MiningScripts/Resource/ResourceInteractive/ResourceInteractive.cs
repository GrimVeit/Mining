using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceInteractive : MonoBehaviour, IPointerClickHandler
{
    public event Action<ResourceType> OnChooseResource;
    public ResourceType ResourceType => resourceType;

    [SerializeField] private Image imageSelectResource;
    [SerializeField] private TextMeshProUGUI textNameResource;
    [SerializeField] private TextMeshProUGUI textMinedCountResources;
    [SerializeField] private TextMeshProUGUI textPriceResource;


    private ResourceType resourceType;

    public void SetData(Resource resource)
    {
        resourceType = resource.Type;
        textNameResource.text = resource.Name;
        textMinedCountResources.text = resource.ResourceData.MineCount.ToString();
        textPriceResource.text = resource.Price.ToString();
    }

    public void SelectResource()
    {
        imageSelectResource.enabled = true;
    }

    public void DeselectResource()
    {
        imageSelectResource.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnChooseResource?.Invoke(resourceType);
    }
}
