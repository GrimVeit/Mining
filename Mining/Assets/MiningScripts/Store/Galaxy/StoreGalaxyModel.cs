using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreGalaxyModel
{
    public event Action<Galaxy> OnSelectOpenGalaxy_Value;
    public event Action<Galaxy> OnSelectCloseGalaxy_Value;
    public event Action<Galaxy> OnDeselectOpenGalaxy_Value;
    public event Action<Galaxy> OnDeselectCloseGalaxy_Value;

    public event Action OnSelectGalaxy;
    public event Action OnDeselectGalaxy;
    public event Action<Galaxy> OnSelectGalaxy_Value;


    public event Action<int> OnOpenGalaxy;
    public event Action<int> OnCloseGalaxy;


    private Galaxys galaxies;

    private Galaxy currentGalaxy;
    private GalaxyData currentGalaxyData;

    private List<GalaxyData> galaxyDatas = new List<GalaxyData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Progress.json");

    public StoreGalaxyModel(Galaxys galaxies)
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

        Debug.Log(galaxies.Galaxies.Count);
        Debug.Log(galaxyDatas.Count);

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

        SelectGalaxy(int.Parse(galaxies.Galaxies.FirstOrDefault(data => data.GalaxyData.IsSelect).GetID()));
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
        if (currentGalaxy != null)
        {
            if (currentGalaxy.GalaxyData.IsOpen)
            {
                OnDeselectOpenGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Deselect открытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }
            else
            {
                OnDeselectCloseGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Deselect закрытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }

            OnDeselectGalaxy?.Invoke();
            currentGalaxy.GalaxyData.IsSelect = false;
        }

        currentGalaxy = galaxies.GetGalaxyByID(number.ToString());

        if (currentGalaxy != null)
        {
            if (currentGalaxy.GalaxyData.IsOpen)
            {
                OnSelectOpenGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Select открытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }
            else
            {
                OnSelectCloseGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Select закрытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }

            currentGalaxy.GalaxyData.IsSelect = true;
            OnSelectGalaxy_Value?.Invoke(currentGalaxy);
            OnSelectGalaxy?.Invoke();
        }
    }

    public void UnselectGalaxy()
    {
        if (currentGalaxy != null)
        {
            if (currentGalaxy.GalaxyData.IsOpen)
            {
                OnDeselectOpenGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Deselect открытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }
            else
            {
                OnDeselectCloseGalaxy_Value?.Invoke(currentGalaxy);

                Debug.Log($"Deselect закрытой галактики под номером {currentGalaxy.GalaxyData.Number}");
            }

            OnDeselectGalaxy?.Invoke();
            currentGalaxy.GalaxyData.IsSelect = false;
        }
    }
}

public class GalaxyDatas
{
    public GalaxyData[] Datas;

    public GalaxyDatas(GalaxyData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class GalaxyData
{
    public int Number;
    public bool IsOpen;
    public bool IsSelect;

    public GalaxyData(int number, bool isOpen, bool isSelect)
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
