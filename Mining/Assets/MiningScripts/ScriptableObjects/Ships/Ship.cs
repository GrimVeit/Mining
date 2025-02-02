using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship")]
public class Ship : ScriptableObject, IIdentify
{
    [SerializeField] private string id;
    [SerializeField] private string nameShip;
    [SerializeField] private Sprite spriteShip;
    [SerializeField] private int loadCapacity;
    [SerializeField] private int countBoats;
    [SerializeField] private int price;
    private ShipData shipData;

    public string GetID() => id;
    public string Name => nameShip;
    public Sprite Sprite => spriteShip;
    public int LoadCapacity => loadCapacity;
    public int CountBoats => countBoats;
    public int Price => price;
    public ShipData ShipData => shipData;


    public void SetData(ShipData shipData)
    {
        this.shipData = shipData;
    }
}
