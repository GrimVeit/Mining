using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GalaxyModel
{
    public event Action<Galaxy> OnSelectOpenGalaxy_Value;
    public event Action<Galaxy> OnSelectCloseGalaxy_Value;
    public event Action<Galaxy> OnDeselectOpenGalaxy_Value;
    public event Action<Galaxy> OnDeselectCloseGalaxy_Value;


    public event Action<int> OnOpenGalaxy;
    public event Action<int> OnCloseGalaxy;


    private Galaxys galaxies;

    private Galaxy currentGalaxy;
    private GalaxyData currentGalaxyData;

    private List<GalaxyData> galaxyDatas = new List<GalaxyData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Progress.json");

    public GalaxyModel(Galaxys galaxies)
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

            for (int i = 0; i < 7; i++)
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


        for (int i = 0; i < galaxyDatas.Count; i++)
        {
            if (galaxyDatas[i].IsOpen)
                OnOpenGalaxy?.Invoke(galaxyDatas[i].Number);
        }


        currentGalaxy = galaxies.GetGalaxyByID(GetSelectProgressData());
        OnSelectOpenGalaxy_Value?.Invoke(currentGalaxy);
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new GalaxyDatas(galaxyDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockGame(int number)
    {
        var progressData = galaxyDatas.FirstOrDefault(gd => gd.Number == number);

        if (progressData != null && !progressData.IsOpen)
        {
            progressData.Open();

            Debug.Log("Unlock Game:" + number);
            for (int i = 0; i < galaxyDatas.Count; i++)
            {
                Debug.Log($"NumberGame - {galaxyDatas[i].Number}, Unlocked - {galaxyDatas[i].IsOpen}");
            }

            OnOpenGalaxy?.Invoke(number);

            return;
        }
    }

    public void SelectGame(int number)
    {
        if(currentGalaxyData != null)
        {
            var galaxy = galaxies.GetGalaxyByID(currentGalaxyData.Number.ToString());

            currentGalaxyData.IsSelect = false;

            if (currentGalaxyData.IsOpen)
            {
                OnDeselectOpenGalaxy_Value?.Invoke(galaxy);
            }
            else
            {
                OnDeselectCloseGalaxy_Value?.Invoke(galaxy);
            }
        }

        currentGalaxyData = galaxyDatas.FirstOrDefault(gd => gd.Number == number);

        if (currentGalaxyData != null)
        {
            currentGalaxyData.IsSelect = true;

            if (currentGalaxyData.IsOpen)
            {
                OnSelectOpenGalaxy_Value?.Invoke(galaxies.GetGalaxyByID(currentGalaxyData.Number.ToString()));
            }
            else
            {
                OnSelectCloseGalaxy_Value?.Invoke(galaxies.GetGalaxyByID(currentGalaxyData.Number.ToString()));
            }
        }
    }


    public bool IsOpenTypeGame(int id)
    {
        return galaxyDatas.FirstOrDefault(data => data.Number == id).IsOpen;
    }


    private string GetSelectProgressData()
    {
        return galaxyDatas.FirstOrDefault(data => data.IsSelect).Number.ToString();
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
