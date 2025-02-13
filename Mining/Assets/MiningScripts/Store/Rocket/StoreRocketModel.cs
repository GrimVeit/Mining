using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreRocketModel
{
    public event Action<Rocket> OnOpenRocket;
    public event Action<Rocket> OnCloseRocket;
    public event Action<Rocket> OnSelectRocket;


    private Rockets rockets;

    private Rocket currentRocket;

    private List<RocketData> rocketDatas = new List<RocketData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Rocket.json");

    private IMoneyProvider moneyProvider;

    public StoreRocketModel(Rockets rockets, IMoneyProvider moneyProvider)
    {
        this.rockets = rockets;
        this.moneyProvider = moneyProvider;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            RocketDatas shipDatas = JsonUtility.FromJson<RocketDatas>(loadedJson);

            Debug.Log("Success");

            this.rocketDatas = shipDatas.Datas.ToList();
        }
        else
        {
            rocketDatas = new List<RocketData>();

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    rocketDatas.Add(new RocketData(false, true));
                }
                else
                {
                    rocketDatas.Add(new RocketData(false, false));
                }
            }
        }

        for (int i = 0; i < rockets.rockets.Count; i++)
        {
            rockets.rockets[i].SetRocketData(rocketDatas[i]);

            if (rocketDatas[i].IsOpen)
                OnOpenRocket?.Invoke(rockets.rockets[i]);
            else
                OnCloseRocket?.Invoke(rockets.rockets[i]);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new RocketDatas(rocketDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void BuyRocket(int number)
    {
        var galaxy = rockets.GetRocketByID(number.ToString());

        if (galaxy.RocketData.IsOpen) return;

        if (moneyProvider.CanAfford(galaxy.Price))
        {
            moneyProvider.SendMoney(-galaxy.Price);

            galaxy.RocketData.IsOpen = true;

            OnOpenRocket?.Invoke(galaxy);
        }
    }

    public void SelectRocket(int number)
    {
        currentRocket = rockets.GetRocketByID(number.ToString());

        OnSelectRocket?.Invoke(currentRocket);
    }
}

public class RocketDatas
{
    public RocketData[] Datas;

    public RocketDatas(RocketData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class RocketData
{
    public bool IsOpen;
    public bool IsSelect;

    public RocketData(bool isOpen, bool isSelect)
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
