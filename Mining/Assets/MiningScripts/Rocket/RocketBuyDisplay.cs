using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketBuyDisplay : MonoBehaviour
{
    [SerializeField] private RocketBuyInteractive rocketBuyInteractivePrefab;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject objectDisplay;

    private List<RocketBuyInteractive> rocketBuyInteractives = new List<RocketBuyInteractive>();

    public void SetRocketVisualize(Rocket rocket)
    {
        var rocketInteractive = rocketBuyInteractives.FirstOrDefault(x => x.ID == int.Parse(rocket.GetID()));

        if(rocketInteractive == null)
        {
            rocketInteractive = Instantiate(rocketBuyInteractivePrefab, content);
            rocketInteractive.OnChooseRocket += HandleChooseRocket;
            rocketBuyInteractives.Add(rocketInteractive);
        }

        rocketInteractive.SetData(rocket);
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        for(int i = 0; i < rocketBuyInteractives.Count; i++)
        {
            rocketBuyInteractives[i].OnChooseRocket -= HandleChooseRocket;
        }
    }

    public void ActivateDisplay()
    {
        objectDisplay.SetActive(true);
    }

    public void DeactivateDisplay()
    {
        objectDisplay.SetActive(false);
    }

    public void SelectRocket(Rocket rocket)
    {
        rocketBuyInteractives.FirstOrDefault(rocketInteractive => rocketInteractive.ID == int.Parse(rocket.GetID())).SelectRocket();
    }

    public void DeselectRocket(Rocket rocket)
    {
        rocketBuyInteractives.FirstOrDefault(rocketInteractive => rocketInteractive.ID == int.Parse(rocket.GetID())).DeselectRocket();
    }

    #region Input

    public event Action<Rocket> OnSelectRocket;

    private void HandleChooseRocket(Rocket rocket)
    {
        OnSelectRocket?.Invoke(rocket);
    }

    #endregion
}
