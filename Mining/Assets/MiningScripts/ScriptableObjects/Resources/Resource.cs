using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource")]
public class Resource : ScriptableObject
{
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private string nameResource;
    [SerializeField] private int price;
    private ResourceData resourceData;

    public string Name => nameResource;
    public ResourceType Type => resourceType;
    public int Price => price;
    public ResourceData ResourceData => resourceData;

    public void SetData(ResourceData resourceData)
    {
        this.resourceData = resourceData;
    }
}
