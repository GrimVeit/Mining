using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceInfo : MonoBehaviour
{
    public ResourceType ResourceType => resourceType;

    [SerializeField] private TextMeshProUGUI textNameResource;
    [SerializeField] private TextMeshProUGUI textMinedCountResources;


    private ResourceType resourceType;

    public void SetData(Resource resource)
    {
        resourceType = resource.Type;
        textNameResource.text = resource.Name;
        textMinedCountResources.text = resource.ResourceData.MineCount.ToString();
    }
}
