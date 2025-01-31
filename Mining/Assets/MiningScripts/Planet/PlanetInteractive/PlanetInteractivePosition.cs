using UnityEngine;

public class PlanetInteractivePosition : MonoBehaviour
{
    public Transform TransformPlanet => transformPositionPlanet;
    public int ID => id;

    [SerializeField] private Transform transformPositionPlanet;

    private int id;

    public void SetID(int id)
    {
        this.id = id;
    }
}
