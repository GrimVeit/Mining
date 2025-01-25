using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planets")]
public class Planets : ScriptableObject
{
    public List<Planet> planets = new List<Planet>();
}
