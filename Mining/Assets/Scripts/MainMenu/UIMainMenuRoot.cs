using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private StartPanel_MainMenuScene startPanel;
    [SerializeField] private MainPanel_MainMenuScene mainPanel;

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
    }

    public void OpenStartPanel()
    {
        OpenPanel(startPanel);
    }

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
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

    #endregion
}
