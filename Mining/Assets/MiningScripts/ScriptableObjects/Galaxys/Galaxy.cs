using UnityEngine;

[CreateAssetMenu(fileName = "Galaxy")]
public class Galaxy : ScriptableObject, IIdentify
{
    [SerializeField] private string id;
    [SerializeField] private int price;

    public GalaxyData GalaxyData;
    public Planets planets;

    public string GetID() => id;
    public int GetPrice() => price;

    public void SetData(GalaxyData galaxyData)
    {
        GalaxyData = galaxyData;
    }
}
