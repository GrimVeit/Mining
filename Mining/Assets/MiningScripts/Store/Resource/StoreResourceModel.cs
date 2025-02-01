using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreResourceModel
{
    public event Action<Resource> OnVisualizeResource;

    public event Action<Resource> OnSelectResource_Value;
    public event Action<Resource> OnDeselectResource_Value;


    private ResourcesGroup resources;

    private Resource currentResource;
    
    private List<ResourceData> resourceDatas = new List<ResourceData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Resources.json");

    private IMoneyProvider moneyProvider;

    public StoreResourceModel(ResourcesGroup resources, IMoneyProvider moneyProvider)
    {
        this.resources = resources;
        this.moneyProvider = moneyProvider;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            ResourceDatas progressDatas = JsonUtility.FromJson<ResourceDatas>(loadedJson);

            this.resourceDatas = progressDatas.Datas.ToList();
        }
        else
        {
            resourceDatas = new List<ResourceData>();

            for (int i = 0; i < 14; i++)
            {
                resourceDatas.Add(new ResourceData(4));
            }
        }

        for (int i = 0; i < resources.resources.Count; i++)
        {
            Debug.Log(resourceDatas.Count);
            resources.resources[i].SetData(resourceDatas[i]);

            OnVisualizeResource?.Invoke(resources.resources[i]);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new ResourceDatas(resourceDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void SelectResource(ResourceType resourceType)
    {
        if (currentResource != null)
        {
            OnDeselectResource_Value?.Invoke(currentResource);
        }

        currentResource = resources.GetResourceByType(resourceType);
        OnSelectResource_Value?.Invoke(currentResource);
    }

    public void SaleSelectResource()
    {
        if(currentResource == null) return;

        var moneyCount = currentResource.Price * currentResource.ResourceData.MineCount;

        moneyProvider.SendMoney(moneyCount);

        currentResource.ResourceData.MineCount = 0;

        OnVisualizeResource.Invoke(currentResource);
    }
}

public class ResourceDatas
{
    public ResourceData[] Datas;

    public ResourceDatas(ResourceData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class ResourceData
{
    public int MineCount;

    public ResourceData(int mineCount)
    {
        MineCount = mineCount;
    }
}

