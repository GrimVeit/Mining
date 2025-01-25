using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniGameSceneRoot : MonoBehaviour
{
    [SerializeField] private MiniGamePanel_MiniGameScene mainPanel;
    [SerializeField] private HeaderPanel_MiniGameScene headerPanel;
    [SerializeField] private FooterPanel_MiniGameScene footerPanel;
    [SerializeField] private WinPanel_MiniGameScene winPanel;
    [SerializeField] private FailPanel_MiniGameScene failPanel;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    private Panel currentPanel;

    public void Initialize()
    {
        headerPanel.SetSoundProvider(soundProvider);
        winPanel.SetSoundProvider(soundProvider);
        failPanel.SetSoundProvider(soundProvider);

        mainPanel.Initialize();
        headerPanel.Initialize();
        footerPanel.Initialize();
        winPanel.Initialize();
        failPanel.Initialize();
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        headerPanel.Dispose();
        footerPanel.Dispose();
        winPanel.Dispose();
        failPanel.Dispose();
    }

    public void Activate()
    {
        headerPanel.OnGoToMainMenu += GoToMainMenu;
        winPanel.OnClickToButtonExit += GoToMainMenu;
        failPanel.OnClickToButtonExit += GoToMainMenu;
        winPanel.OnClickToButtonRestart += GoToRestart;
        failPanel.OnClickToButtonRestart += GoToRestart;
    }

    public void Deactivate()
    {
        headerPanel.OnGoToMainMenu -= GoToMainMenu;
        winPanel.OnClickToButtonExit -= GoToMainMenu;
        failPanel.OnClickToButtonExit -= GoToMainMenu;
        winPanel.OnClickToButtonRestart -= GoToRestart;
        failPanel.OnClickToButtonRestart -= GoToRestart;

        CloseOtherPanel(currentPanel);
    }



    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }



    public void OpenWinPanel()
    {
        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        CloseOtherPanel(winPanel);
    }



    public void OpenFailPanel()
    {
        OpenOtherPanel(failPanel);
    }

    public void CloseFailPanel()
    {
        CloseOtherPanel(failPanel);
    }



    public void OpenFooterPanel()
    {
        OpenOtherPanel(footerPanel);
    }

    public void CloseFooterPanel()
    {
        CloseOtherPanel(footerPanel);
    }



    public void OpenHeaderPanel()
    {
        OpenOtherPanel(headerPanel);
    }

    public void CloseHeaderPanel()
    {
        CloseOtherPanel(headerPanel);
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

    public event Action OnGoToMainMenu;
    public event Action OnGoToRestart;

    private void GoToMainMenu()
    {
        OnGoToMainMenu?.Invoke();
    }

    private void GoToRestart()
    {
        OnGoToRestart?.Invoke();
    }

    #endregion
}
