using UnityEngine;

[CreateAssetMenu(fileName = "Planet")]
public class Planet : ScriptableObject, IIdentify
{
    [SerializeField] private string id;
    [SerializeField] private string namePlanet;
    [SerializeField] private ResourceType resourceType;
    [SerializeField] private PlanetType planetType;
    [SerializeField] private int planetPrice;
    [SerializeField] private int resourceReserve;
    [SerializeField] private Sprite planetSprite;

    private PlanetData planetData;
    private RocketPlanetData rocketPlanetData;

    public string GetID() => id;
    public string NamePlanet => namePlanet;
    public int Price => planetPrice;
    public ResourceType ResourceType => resourceType;
    public PlanetType PlanetType => planetType;
    public int ResourceReserve => resourceReserve;
    public Sprite PlanetSprite => planetSprite;
    public PlanetData PlanetData => planetData;
    public RocketPlanetData RocketPlanetData => rocketPlanetData;

    public void SetPlanetData(PlanetData data)
    {
        planetData = data;
    }

    public void SetRocketPlanetData(RocketPlanetData rocketUpgradeData)
    {
        this.rocketPlanetData = rocketUpgradeData;
    }
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
