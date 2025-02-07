using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTransferView : View
{
    [SerializeField] private RocketTransfer rocketTransferPrefab;
    [SerializeField] private Transform transformShip;

    private List<RocketTransfer> rocketTransfers = new List<RocketTransfer>();

    public void ActivateRocket(Planet planet)
    {
        var transfer = Instantiate(rocketTransferPrefab, transformShip);
        transfer.SetData(planet, transformShip);
        transfer.Initialize();

        rocketTransfers.Add(transfer);
    }
}
