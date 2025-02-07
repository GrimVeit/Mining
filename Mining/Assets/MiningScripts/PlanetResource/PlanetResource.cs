using System;

public class PlanetResource : IPlanetResource
{
    public Planet CurrentPlanet { get; private set; }

    public event Action<int, float> OnChangePlanetResourceData;

    public event Action<Planet> OnEndResources;

    public float PersentMined() => MathF.Round(((float)allResourceCount - currentResourceCount) / allResourceCount * 100f * 1f, 2);
    public int AllResourceCount() => allResourceCount;
    public int ResourceCount() => currentResourceCount;
    public int PlanetID() => int.Parse(CurrentPlanet.GetID());

    private float percentMined;
    private int currentResourceCount;
    private int allResourceCount;

    public void SetPlanet(Planet planet)
    {
        CurrentPlanet = planet;

        allResourceCount = planet.ResourceReserve;
        currentResourceCount = allResourceCount;
    }

    public void PickUpResource(int count)
    {
        if(currentResourceCount >= count)
        {
            currentResourceCount -= count;
        } 
        else if(currentResourceCount <= 0)
        {
            currentResourceCount = 0;
            OnEndResources?.Invoke(CurrentPlanet);
        }

        percentMined = MathF.Round((((float)allResourceCount - currentResourceCount) / allResourceCount * 100f * 1f), 2);
        OnChangePlanetResourceData?.Invoke(allResourceCount - currentResourceCount, percentMined);
    }

    public bool CanAfford(int count)
    {
        return currentResourceCount >= count;
    }
}

public interface IPlanetResource
{
    public int ResourceCount();
    public int PlanetID();
    public bool CanAfford(int count);
    public void PickUpResource(int count);
}
