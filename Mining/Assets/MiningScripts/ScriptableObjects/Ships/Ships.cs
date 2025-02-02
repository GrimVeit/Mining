using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Ships")]
public class Ships : ScriptableObject
{
    public List<Ship> ships = new List<Ship>();

    public Ship GetShipByID(string id)
    {
        return ships.FirstOrDefault(ship => ship.GetID() == id);
    }
}
