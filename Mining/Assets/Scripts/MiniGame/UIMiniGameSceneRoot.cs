using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniGameSceneRoot : MonoBehaviour
{
    [SerializeField] private GameplayButtonsPanel gameplayButtonsPanel;
    [SerializeField] private PlanetInfoPanel planetInfoPanel;
    [SerializeField] private ShopPanel_MiniGameScene shopPanel;
    [SerializeField] private ResourceDescriptionPanel resourceDescriptionPanel;
    [SerializeField] private ResourceSalePanel resourceSalePanel;
    [SerializeField] private ExitPanel exitPanel;

    private ISoundProvider soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this.soundProvider = soundProvider;
    }

    private Panel currentPanel;

    public void Initialize()
    {
        gameplayButtonsPanel.Initialize();
        planetInfoPanel.Initialize();
        shopPanel.Initialize();
        resourceDescriptionPanel.Initialize();
        resourceSalePanel.Initialize();
        exitPanel.Initialize();
    }

    public void Dispose()
    {
        gameplayButtonsPanel.Dispose();
        planetInfoPanel.Dispose();
        shopPanel.Dispose();
        resourceDescriptionPanel.Dispose();
        resourceSalePanel.Dispose();
        exitPanel.Dispose();
    }




    public void Activate()
    {
        OpenGameplayButtonsPanel();
    }

    public void Deactivate()
    {
        //CloseOtherPanel(currentPanel);
    }





    public void OpenGameplayButtonsPanel()
    {
        OpenOtherPanel(gameplayButtonsPanel);
    }

    public void CloseGameplayButtonsPanel()
    {
        CloseOtherPanel(gameplayButtonsPanel);
    }




    public void OpenPlanetInfoPanel()
    {
        if (planetInfoPanel.IsActive) return;

        OpenOtherPanel(planetInfoPanel);
    }

    public void ClosePlanetInfoPanel()
    {
        CloseOtherPanel(planetInfoPanel);
    }




    public void OpenShopPanel()
    {
        if(shopPanel.IsActive) return;

        OpenOtherPanel(shopPanel);
    }

    public void CloseShopPanel()
    {
        CloseOtherPanel(shopPanel);
    }


    
    public void OpenResourceDescriptionPanel()
    {
        if(resourceDescriptionPanel.IsActive) return;

        OpenOtherPanel(resourceDescriptionPanel);
    }

    public void CloseResourceDescriptionPanel()
    {
        CloseOtherPanel(resourceDescriptionPanel);
    }




    public void OpenResourceSalePanel()
    {
        if(resourceSalePanel.IsActive) return;

        OpenOtherPanel(resourceSalePanel);
    }

    public void CloseResourceSalePanel()
    {
        CloseOtherPanel(resourceSalePanel);
    }

    


    public void OpenExitPanel()
    {
        if(exitPanel.IsActive) return;

        OpenOtherPanel(exitPanel);
    }

    public void CloseExitPanel()
    {
        CloseOtherPanel(exitPanel);
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

    public event Action OnClickToClose_Shop
    {
        add { shopPanel.OnClickToClosePanel += value; }
        remove { shopPanel.OnClickToClosePanel -= value; }
    }

    public event Action OnClickToClose_ResourceDescription
    {
        add { resourceDescriptionPanel.OnClickToClosePanel += value; }
        remove { resourceDescriptionPanel.OnClickToClosePanel -= value; }
    }

    public event Action OnClickToClose_ResourceSale
    {
        add { resourceSalePanel.OnClickToClosePanel += value; }
        remove { resourceSalePanel.OnClickToClosePanel -= value; }
    }





    public event Action OnClickToOpen_PlanetInfo
    {
        add { gameplayButtonsPanel.OnClickToOpen_PlanetInfo += value; }
        remove { gameplayButtonsPanel.OnClickToOpen_PlanetInfo -= value; }
    }

    public event Action OnClickToOpen_ResourceDescription
    {
        add { gameplayButtonsPanel.OnClickToOpen_ResourceDescription += value; }
        remove { gameplayButtonsPanel.OnClickToOpen_ResourceDescription -= value; }
    }

    public event Action OnClickToOpen_ResourceSale
    {
        add { gameplayButtonsPanel.OnClickToOpen_ResourceSale += value; }
        remove { gameplayButtonsPanel.OnClickToOpen_ResourceSale -= value; }
    }

    public event Action OnClickToOpen_Shop
    {
        add { gameplayButtonsPanel.OnClickToOpen_Shop += value; }
        remove { gameplayButtonsPanel.OnClickToOpen_Shop -= value; }
    }

    public event Action OnClickToOpen_Map
    {
        add { gameplayButtonsPanel.OnClickToOpen_Map += value; }
        remove { gameplayButtonsPanel.OnClickToOpen_Map -= value; }
    }





    public event Action OnClickToExit
    {
        add { exitPanel.OnClickToExit += value; }
        remove { exitPanel.OnClickToExit -= value; }
    }

    public event Action OnClickToCancelExit
    {
        add { exitPanel.OnClickToCancel += value; }
        remove { exitPanel.OnClickToCancel -= value; }
    }

    #endregion
}
