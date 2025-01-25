using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Galaxys")]
public class Galaxys : ScriptableObject
{
    public List<Galaxy> Galaxies = new List<Galaxy>();

    public Galaxy GetGalaxyByID(string id)
    {
        return Galaxies.FirstOrDefault(data => data.GetID() == id);
    }
}
