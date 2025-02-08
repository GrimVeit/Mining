using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private StartPanel_MainMenuScene startPanel;
    [SerializeField] private MainPanel_MainMenuScene mainPanel;
    [SerializeField] private GalaxyInfoPanel galaxyInfoPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.SetSoundProvider(soundProvider);
        startPanel.SetSoundProvider(soundProvider);

        startPanel.Initialize();
        mainPanel.Initialize();
        galaxyInfoPanel.Initialize();

    }

    public void Activate()
    {
        OpenStartPanel();
    }

    public void Deactivate()
    {
        currentPanel.DeactivatePanel();
    }

    public void Dispose()
    {
        startPanel?.Dispose();
        mainPanel?.Dispose();
        galaxyInfoPanel?.Dispose();
    }



    public void OpenStartPanel()
    {
        OpenPanel(startPanel);
    }

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    

    public void OpenGalaxyInfoPanel()
    {
        if (galaxyInfoPanel.IsActive) return;

        OpenOtherPanel(galaxyInfoPanel);
    }

    public void CloseGalaxyInfoPanel()
    {
        CloseOtherPanel(galaxyInfoPanel);
    }


    private void OpenPanel(Panel panel)
    {
        if(currentPanel == panel) return;

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

    public event Action OnGoToMain
    {
        add { startPanel.OnGoToMain += value; }
        remove { startPanel.OnGoToMain -= value; }
    }

    public event Action OnCloseGalaxyInfoPanel
    {
        add { galaxyInfoPanel.OnClose += value; }
        remove { galaxyInfoPanel.OnClose -= value; }
    }

    #endregion
}
