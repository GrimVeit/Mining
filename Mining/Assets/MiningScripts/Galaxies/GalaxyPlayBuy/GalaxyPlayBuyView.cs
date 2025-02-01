using System;
using UnityEngine;

public class GalaxyPlayBuyView : View
{
    [SerializeField] private GalaxyBuyDisplay buyDisplay;
    [SerializeField] private GalaxyPlayDisplay playDisplay;

    public void Initialize()
    {
        buyDisplay.OnClickToBuy += HandleClickToBuy;
        playDisplay.OnClickToPlay += HandleClickToPlay;

        buyDisplay.Initialize();
        playDisplay.Initialize();
    }

    public void Dispose()
    {
        buyDisplay.OnClickToBuy -= HandleClickToBuy;
        playDisplay.OnClickToPlay -= HandleClickToPlay;

        buyDisplay.Dispose();
        playDisplay.Dispose();
    }

    public void OpenBuyDisplay(int coins)
    {
        buyDisplay.SetPrice(coins);

        playDisplay.CloseDisplay();
        buyDisplay.OpenDisplay();
    }

    public void OpenPlayDisplay()
    {
        buyDisplay.CloseDisplay();
        playDisplay.OpenDisplay();
    }

    #region Input

    public event Action OnClickToPlay;
    public event Action OnClickToBuy;

    private void HandleClickToPlay()
    {
        OnClickToPlay?.Invoke();
    }

    private void HandleClickToBuy()
    {
        OnClickToBuy?.Invoke();
    }

    #endregion
}
