using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartRoot : MonoBehaviour
{
    [SerializeField] private StartPanel_MainMenuScene startPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        startPanel.SetSoundProvider(soundProvider);

    }

    public void Activate()
    {
        OpenStartPanel();
    }

    public void Deactivate()
    {
        currentPanel?.DeactivatePanel();
    }

    public void Dispose()
    {
        startPanel.Dispose();
    }



    public void OpenStartPanel()
    {
        OpenPanel(startPanel);
    }




    private void OpenPanel(Panel panel)
    {
        if (currentPanel == panel) return;

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


    #region Input Actions

    public event Action OnGoToMap
    {
        add { startPanel.OnGoToMain += value; }
        remove { startPanel.OnGoToMain -= value; }
    }

    #endregion
}
