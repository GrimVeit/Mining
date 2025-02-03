using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Planets")]
public class Planets : ScriptableObject
{
    public List<Planet> planets = new List<Planet>();

    public Planet GetPlanetById(string id)
    {
        return planets.FirstOrDefault(planet => planet.GetID() == id);
    }
}
