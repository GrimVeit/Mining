using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniGameSceneRoot : MonoBehaviour
{
    [SerializeField] private PlanetInfoPanel planetInfoPanel;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    private Panel currentPanel;

    public void Initialize()
    {
        planetInfoPanel.Initialize();
    }

    public void Dispose()
    {
        planetInfoPanel.Dispose();
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

        CloseOtherPanel(currentPanel);
    }




    public void OpenPlanetInfoPanel()
    {
        OpenOtherPanel(planetInfoPanel);
    }

    public void ClosePlanetInfoPanel()
    {
        CloseOtherPanel(planetInfoPanel);
    }



    private void OpenPanel(Panel panel)
    {
        if (currentPanel != null)
            currentPanel.DeactivatePanel();

        currentPanel = panel;
        currentPanel.ActivatePanel();

    }

    private void OpenOtherPanel(Panel panel)
    {
        panel.ActivatePanel();
    }

    private void CloseOtherPanel(Panel panel)
    {
        panel.DeactivatePanel();
    }

    #region Input

    public event Action OnClickToClose_InfoPlanet
    {
        add { planetInfoPanel.OnClickToClosePanel += value; }
        remove { planetInfoPanel.OnClickToClosePanel -= value; }
    }

    #endregion
}
