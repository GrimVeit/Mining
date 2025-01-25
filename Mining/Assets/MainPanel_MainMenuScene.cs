using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_MainMenuScene : MovePanel
{
    //[SerializeField] private Button play_Button;

    public event Action OnGoToShop;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        //play_Button.onClick.AddListener(HandleGoToChooseGamePanel);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        //play_Button.onClick.RemoveListener(HandleGoToChooseGamePanel);
    }

    private void HandleGoToChooseGamePanel()
    {
        soundProvider.PlayOneShot("Button_Click");
        OnGoToShop?.Invoke();
    }
}
