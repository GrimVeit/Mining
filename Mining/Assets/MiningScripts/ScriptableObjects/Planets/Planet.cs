using UnityEngine;

[CreateAssetMenu(fileName = "Planet")]
public class Planet : ScriptableObject, IIdentify
{
    [SerializeField] private string id;
    [SerializeField] private string namePlanet;
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private PlanetType planetType;

    public string GetID() => id;
    public string NamePlanet => namePlanet;
    public ResourceType ResourceType => resourceType;
    public PlanetType PlanetType => planetType;
}

public enum ResourceType
{
    Copper,
    Iron,
    Lead,
    Silicon,
    Aluminum,
    Silver,
    Gold,
    Titanium,
    Emeralds,
    Platinum,
    UraniumOres,
    Nickel,
    Tin,
    Tungsten
}

public enum PlanetType
{
    High,
    Low,
    Middle
}
