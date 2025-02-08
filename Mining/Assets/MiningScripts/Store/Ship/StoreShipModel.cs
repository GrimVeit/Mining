using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreShipModel
{
    public event Action<Ship> OnOpenShip;
    public event Action<Ship> OnCloseShip;
    public event Action<Ship> OnSelectShip;


    private Ships ships;

    private Ship currentShip;
    private ShipData currentGalaxyData;

    private List<ShipData> shipDatas = new List<ShipData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Ship.json");

    private IMoneyProvider moneyProvider;

    public StoreShipModel(Ships ships, IMoneyProvider moneyProvider)
    {
        this.ships = ships;
        this.moneyProvider = moneyProvider;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            ShipDatas shipDatas = JsonUtility.FromJson<ShipDatas>(loadedJson);

            Debug.Log("Success");

            this.shipDatas = shipDatas.Datas.ToList();
        }
        else
        {
            shipDatas = new List<ShipData>();

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    shipDatas.Add(new ShipData(true, true));
                }
                else
                {
                    shipDatas.Add(new ShipData(false, false));
                }
            }
        }

        for (int i = 0; i < ships.ships.Count; i++)
        {
            ships.ships[i].SetData(shipDatas[i]);

            if(shipDatas[i].IsOpen)
                OnOpenShip?.Invoke(ships.ships[i]);
            else
                OnCloseShip?.Invoke(ships.ships[i]);
        }

        SelectGalaxy(GetSelectGalaxyIndex());
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new ShipDatas(shipDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void BuyShip(int number)
    {
        var galaxy = ships.GetShipByID(number.ToString());

        if(galaxy.ShipData.IsOpen) return;

        if (moneyProvider.CanAfford(galaxy.Price))
        {
            moneyProvider.SendMoney(-galaxy.Price);

            galaxy.ShipData.IsOpen = true;

            OnOpenShip?.Invoke(galaxy);
        }
    }

    public void SelectGalaxy(int number)
    {
        currentShip = ships.GetShipByID(number.ToString());

        OnSelectShip?.Invoke(currentShip);
    }


    private int GetSelectGalaxyIndex()
    {
        return int.Parse(ships.ships.FirstOrDefault(ship => ship.ShipData.IsSelect == true).GetID());
    }
}

public class ShipDatas
{
    public ShipData[] Datas;

    public ShipDatas(ShipData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class ShipData
{
    public bool IsOpen;
    public bool IsSelect;

    public ShipData(bool isOpen, bool isSelect)
    {
        this.IsOpen = isOpen;
        this.IsSelect = isSelect;
    }

    public void Select()
    {
        IsSelect = true;
    }

    public void Open()
    {
        IsOpen = true;
    }
}
