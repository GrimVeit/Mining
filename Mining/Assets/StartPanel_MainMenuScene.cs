using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel_MainMenuScene : MovePanel
{
    [SerializeField] private Button play_Button;

    public event Action OnGoToMain;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        play_Button.onClick.AddListener(HandleGoToMainPanel);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        play_Button.onClick.RemoveListener(HandleGoToMainPanel);
    }

    private void HandleGoToMainPanel()
    {
        //soundProvider.PlayOneShot("Button_Click");
        OnGoToMain?.Invoke();
    }
}
