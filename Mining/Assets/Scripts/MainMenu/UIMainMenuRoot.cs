using System;
using UnityEngine;

public class UIMainMenuRoot : MonoBehaviour
{
    [SerializeField] private MainPanel_MainMenuScene mainPanel;
    [SerializeField] private ShopPanel_MainMenuScene shopPanel;
    [SerializeField] private SpinPackPanel_MainMenuScene spinPackPanel;
    [SerializeField] private OpenPackPanel_MainMenuScene openPackPanel;
    [SerializeField] private HeaderCollectionPanel_MainMenuScene headerCollectionPanel;
    [SerializeField] private CollectionPanel_MainMenuScene collectionPanel;

    private ISoundProvider soundProvider;

    private Panel currentPanel;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.SetSoundProvider(soundProvider);
        shopPanel.SetSoundProvider(soundProvider);
        collectionPanel.SetSoundProvider(soundProvider);

        mainPanel.Initialize();
        openPackPanel.Initialize();
        shopPanel.Initialize();
        spinPackPanel.Initialize();
        collectionPanel.Initialize();
        headerCollectionPanel.Initialize();
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {
        currentPanel.DeactivatePanel();
    }

    public void Dispose()
    {
        mainPanel?.Dispose();
        shopPanel?.Dispose();
        spinPackPanel?.Dispose();
        openPackPanel?.Dispose();
        collectionPanel?.Dispose();
        headerCollectionPanel?.Dispose();
    }

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenShopPanel()
    {
        OpenPanel(shopPanel);
    }

    public void OpenSpinPackPanel()
    {
        OpenPanel(spinPackPanel);
    }

    public void OpenCollectionPanel()
    {
        OpenPanel(collectionPanel);
    }

    public void OpenPackPanel()
    {
        OpenPanel(openPackPanel);
    }


    public void OpenCollectionHeaderPanel()
    {
        OpenOtherPanel(headerCollectionPanel);
    }

    public void CloseCollectionHeaderPanel()
    {
        CloseOtherPanel(headerCollectionPanel);
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

    public event Action OnGoToShop
    {
        add { mainPanel.OnGoToShop += value; }
        remove { mainPanel.OnGoToShop -= value; }
    }

    public event Action OnGoToGame
    {
        add { shopPanel.OnClickPlayButton += value; }
        remove { shopPanel.OnClickPlayButton -= value; }
    }

    public event Action OnClickCollectionsButton
    {
        add { shopPanel.OnClickCollectionsButton += value; }
        remove { shopPanel.OnClickCollectionsButton -= value; }
    }

    public event Action OnClickBackButtonFromShopPanel
    {
        add { shopPanel.OnClickBackButton += value; }
        remove { shopPanel.OnClickBackButton -= value; }
    }

    public event Action OnClickBackButtonFromCollectionPanel
    {
        add { collectionPanel.OnClickToBackButton += value; }
        remove {  collectionPanel.OnClickToBackButton -= value; }
    }

    #endregion
}
