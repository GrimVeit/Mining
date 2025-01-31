using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreShipModel : MonoBehaviour
{
    public event Action<int> OnOpenGalaxy;
    public event Action<int> OnCloseGalaxy;


    private Galaxys galaxies;

    private Galaxy currentGalaxy;
    private GalaxyData currentGalaxyData;

    private List<GalaxyData> galaxyDatas = new List<GalaxyData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Progress.json");

    public StoreShipModel(Galaxys galaxies)
    {
        this.galaxies = galaxies;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            GalaxyDatas progressDatas = JsonUtility.FromJson<GalaxyDatas>(loadedJson);

            Debug.Log("Success");

            this.galaxyDatas = progressDatas.Datas.ToList();
        }
        else
        {
            galaxyDatas = new List<GalaxyData>();

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    galaxyDatas.Add(new GalaxyData(i, true, true));
                }
                else
                {
                    galaxyDatas.Add(new GalaxyData(i, false, false));
                }
            }
        }

        for (int i = 0; i < galaxies.Galaxies.Count; i++)
        {
            galaxies.Galaxies[i].SetData(galaxyDatas[i]);
        }


        for (int i = 0; i < galaxyDatas.Count; i++)
        {
            if (galaxyDatas[i].IsOpen)
                OnOpenGalaxy?.Invoke(galaxyDatas[i].Number);

            if (!galaxyDatas[i].IsOpen)
                OnCloseGalaxy?.Invoke(galaxyDatas[i].Number);
        }

        SelectGalaxy(GetSelectGalaxy());
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new GalaxyDatas(galaxyDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockGalaxy(int number)
    {
        var galaxy = galaxies.GetGalaxyByID(number.ToString());

        if (galaxy != null && !galaxy.GalaxyData.IsOpen)
        {
            galaxy.GalaxyData.IsOpen = true;

            OnOpenGalaxy?.Invoke(number);

            SelectGalaxy(number);
        }
    }

    public void SelectGalaxy(int number)
    {

    }


    private int GetSelectGalaxy()
    {
        return galaxyDatas.FirstOrDefault(data => data.IsSelect).Number;
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
    public int Number;
    public bool IsOpen;
    public bool IsSelect;

    public ShipData(int number, bool isOpen, bool isSelect)
    {
        this.Number = number;
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
