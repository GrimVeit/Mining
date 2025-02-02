using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Rocket")]
public class Rocket : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string nameRocket;
    [SerializeField] private Sprite spriteRocket;
    [SerializeField] private int baseLoadCapacity;
    [SerializeField] private int price;
    private RocketData rocketData;

    public string GetID() => id;
    public string Name => nameRocket;
    public Sprite Sprite => spriteRocket;
    public int BaseLoadCapacity => baseLoadCapacity;
    public int Price => price;
    public RocketData RocketData => rocketData;

    public void SetData(RocketData rocketData)
    {
        this.rocketData = rocketData;
    }
}
