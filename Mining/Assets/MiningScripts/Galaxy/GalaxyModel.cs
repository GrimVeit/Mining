using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GalaxyModel
{
    public event Action<Galaxy> OnChooseOpenGalaxy_Value;
    public event Action<Galaxy> OnChooseCloseGalaxy_Value;
    public event Action<int> OnOpenGameType;
    public event Action OnChooseGameType;


    private Galaxys galaxies;

    private Galaxy currentGalaxy;
    private List<GalaxyData> progressDatas = new List<GalaxyData>();

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

            this.progressDatas = progressDatas.Datas.ToList();
        }
        else
        {
            progressDatas = new List<GalaxyData>();

            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    progressDatas.Add(new GalaxyData(i, true, true));
                }
                else
                {
                    progressDatas.Add(new GalaxyData(i, false, false));
                }
            }
        }


        for (int i = 0; i < progressDatas.Count; i++)
        {
            if (progressDatas[i].IsOpen)
                OnOpenGameType?.Invoke(progressDatas[i].Number);
        }


        currentGalaxy = galaxies.GetGalaxyByID(GetSelectProgressData());
        OnChooseOpenGalaxy_Value?.Invoke(currentGalaxy);
        OnChooseGameType?.Invoke();
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new GalaxyDatas(progressDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockGame(int number)
    {
        var progressData = progressDatas.FirstOrDefault(gd => gd.Number == number);

        if (progressData != null && !progressData.IsOpen)
        {
            progressData.Open();

            Debug.Log("Unlock Game:" + number);
            for (int i = 0; i < progressDatas.Count; i++)
            {
                Debug.Log($"NumberGame - {progressDatas[i].Number}, Unlocked - {progressDatas[i].IsOpen}");
            }

            OnOpenGameType?.Invoke(number);

            return;
        }
    }

    public void SelectGame(int number)
    {
        var currentSelectGame = progressDatas.FirstOrDefault(data => data.IsSelect);
        currentSelectGame.IsSelect = false;

        var progressData = progressDatas.FirstOrDefault(gd => gd.Number == number);

        if (progressData != null && progressData.IsOpen)
        {
            if (progressData.IsOpen)
            {
                progressData.Select();

                OnChooseOpenGalaxy_Value?.Invoke(galaxies.GetGalaxyByID(progressData.Number.ToString()));
                OnChooseGameType?.Invoke();
            }
            else
            {
                OnChooseCloseGalaxy_Value?.Invoke(galaxies.GetGalaxyByID(progressData.Number.ToString()));
            }
        }
    }


    public bool IsOpenTypeGame(int id)
    {
        return progressDatas.FirstOrDefault(data => data.Number == id).IsOpen;
    }


    private string GetSelectProgressData()
    {
        return progressDatas.FirstOrDefault(data => data.IsSelect).Number.ToString();
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
