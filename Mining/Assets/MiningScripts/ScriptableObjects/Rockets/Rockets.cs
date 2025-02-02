using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Rockets")]
public class Rockets : ScriptableObject
{
   public List<Rocket> rockets = new List<Rocket>();

    public Rocket GetRocketByID(string id)
    {
        return rockets.FirstOrDefault(rocket => rocket.GetID() == id);
    }
}
