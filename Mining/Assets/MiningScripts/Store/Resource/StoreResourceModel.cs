using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreResourceModel
{
    public event Action<ResourcesGroup> OnSetResources;

    public event Action<Resource> OnSelectResource_Value;
    public event Action<Resource> OnDeselectResource_Value;


    private ResourcesGroup resources;

    private Resource currentResource;
    
    private List<ResourceData> resourceDatas = new List<ResourceData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Resources.json");

    public StoreResourceModel(ResourcesGroup resources)
    {
        this.resources = resources;
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
                resourceDatas.Add(new ResourceData(0));
            }
        }

        for (int i = 0; i < resources.resources.Count; i++)
        {
            Debug.Log(resourceDatas.Count);
            resources.resources[i].SetData(resourceDatas[i]);
        }

        OnSetResources?.Invoke(resources);
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

    //public void AddResource(ResourceType resourceType, int count)
    //{

    //}

    //public void RemoveResource(ResourceType resourceType)
    //{

    //}
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

