using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRocketUpgradeView : View
{
    [SerializeField] private GameObject objectUpgradeDisplay;
    [SerializeField] private PlanetRocketUpgradeInteractive speedInteractive;
    [SerializeField] private PlanetRocketUpgradeInteractive capacityInteractive;
    [SerializeField] private TextMeshProUGUI textRocketName;
    [SerializeField] private TextMeshProUGUI textSpeed;
    [SerializeField] private TextMeshProUGUI textCapacity;

    [SerializeField] private Button buttonUpgradeSpeed;
    [SerializeField] private Button buttonUpgradeCapacity;
    [SerializeField] private TextMeshProUGUI textPriceSecondSpeed;
    [SerializeField] private TextMeshProUGUI textPriceSecondCapacity;
 
    public void Initialize()
    {
        buttonUpgradeSpeed.onClick.AddListener(()=> OnClickToUpgradeSpeed?.Invoke());
        buttonUpgradeCapacity.onClick.AddListener(() => OnClickToUpgradeCapacity?.Invoke());

        speedInteractive.OnChoose += HandleSelectSpeed;
        capacityInteractive.OnChoose += HandleSelectCapacity;
    }

    public void Dispose()
    {
        buttonUpgradeSpeed.onClick.RemoveListener(() => OnClickToUpgradeSpeed?.Invoke());
        buttonUpgradeCapacity.onClick.RemoveListener(() => OnClickToUpgradeCapacity?.Invoke());

        speedInteractive.OnChoose -= HandleSelectSpeed;
        capacityInteractive.OnChoose -= HandleSelectCapacity;
    }

    public void SetRocketPlanetData(RocketPlanetData data)
    {
        textRocketName.text = $"{data.Rocket.Name} rocket";
        textSpeed.text = data.Speed.ToString();
        textCapacity.text = data.Capacity.ToString();
    }

    public void ActivateRocketUpgradeDisplay()
    {
        objectUpgradeDisplay.SetActive(true);
    }

    public void DeactivateRocketUpgradeDisplay()
    {
        objectUpgradeDisplay.SetActive(false);
    }





    public void SelectSpeedInteractive()
    {
        speedInteractive.SelectUpgrade();
        capacityInteractive.DeselectUpgrade();
    }

    public void SelectCapacityInteractive()
    {
        speedInteractive.DeselectUpgrade();
        capacityInteractive.SelectUpgrade();
    }







    public void ActivateSpeedButton(int price)
    {
        buttonUpgradeSpeed.gameObject.SetActive(true);
        textPriceSecondSpeed.text = price.ToString();
    }

    public void DeactivateSpeedButton()
    {
        buttonUpgradeSpeed.gameObject.SetActive(false);
    }

    public void ActivateCapacityButton(int price)
    {
        buttonUpgradeCapacity.gameObject.SetActive(true);
        textPriceSecondCapacity.text = price.ToString();
    }

    public void DeactivateCapacityButton()
    {
        buttonUpgradeCapacity.gameObject.SetActive(false);
    }


    public void AllDeactivate()
    {
        speedInteractive.DeselectUpgrade();
        capacityInteractive.DeselectUpgrade();

        DeactivateCapacityButton();
        DeactivateSpeedButton();
    }


    #region Input

    public event Action OnSelectSpeed;
    public event Action OnSelectCapacity;

    public event Action OnClickToUpgradeSpeed;
    public event Action OnClickToUpgradeCapacity;

    private void HandleSelectSpeed()
    {
        OnSelectSpeed?.Invoke();
    }

    private void HandleSelectCapacity()
    {
        OnSelectCapacity?.Invoke();
    }

    #endregion
}
