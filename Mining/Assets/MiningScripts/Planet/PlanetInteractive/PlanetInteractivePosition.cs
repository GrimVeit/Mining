using UnityEngine;

public class PlanetInteractivePosition : MonoBehaviour
{
    public Transform TransformPlanet => transformPositionPlanet;
    public int PlanetID => planetID;

    [SerializeField] private Transform transformPositionPlanet;

    private int planetID;

    public void SetID(int id)
    {
        this.planetID = id;
    }
}
