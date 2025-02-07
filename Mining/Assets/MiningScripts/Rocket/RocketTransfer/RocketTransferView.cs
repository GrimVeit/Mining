using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketTransferView : View
{
    [SerializeField] private RocketTransfer rocketTransferPrefab;
    [SerializeField] private Transform transformParent;
    [SerializeField] private Transform transformShip;

    private List<RocketTransfer> rocketTransfers = new List<RocketTransfer>();

    public void SpawnRocket(Planet planet, IPlanetResource planetResource)
    {
        var transfer = Instantiate(rocketTransferPrefab, transformParent);
        transfer.SetData(planet, planetResource, transformShip);
        transfer.OnSendResources += HandleSendResources;
        transfer.Initialize();

        rocketTransfers.Add(transfer);
    }

    public void Dispose()
    {
        rocketTransfers.ForEach((data) =>
        {
            data.OnSendResources -= HandleSendResources;
        });

        rocketTransfers.Clear();
    }

    public void ReturnRocketToShip(int id)
    {
        //rocketTransfers.FirstOrDefault(data => data.ID == id)
    }

    #region Input

    public event Action<ResourceType, int> OnSendResources;

    private void HandleSendResources(ResourceType resourceType, int countResources)
    {
        OnSendResources?.Invoke(resourceType, countResources);
    }

    #endregion
}
