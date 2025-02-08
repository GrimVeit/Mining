using System;
using UnityEngine;

public class MiniGameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Galaxys galaxies;
    [SerializeField] private Ships ships;
    [SerializeField] private Rockets rockets;
    [SerializeField] private RocketBuyLevelPrices prices;
    [SerializeField] private RocketUpgradeLevelPrices upgradeLevelPrices;
    [SerializeField] private ResourcesGroup resources;
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMiniGameSceneRoot sceneRootPrefab;

    private UIMiniGameSceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private SoundPresenter soundPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private BankPresenter bankPresenter;

    private StoreGalaxyPresenter storeGalaxyPresenter;
    private StorePlanetPresenter storePlanetPresenter;
    private PlanetInteractivePresenter planetInteractivePresenter;
    private PlanetInfoPresenter planetInfoPresenter;

    private StoreResourcePresenter storeResourcePresenter;
    private ResourceInteractivePresenter resourceInteractivePresenter;
    private ResourceInfoPresenter resourceInfoPresenter;

    private StoreShipPresenter storeShipPresenter;
    private ShopShipPresenter shopShipPresenter;

    private StoreRocketPresenter storeRocketPresenter;
    private ShopRocketPresenter shopRocketPresenter;

    private PlanetBuyPresenter planetBuyPresenter;
    private RocketBuyPresenter rocketBuyPresenter;

    private PlanetRocketUpgradePresenter planetRocketUpgradePresenter;

    private RocketTransferPresenter rocketTransferPresenter;

    private PlanetResourcePresenter planetResourcePresenter;

    private PlanetRocketVisualPresenter planetRocketVisualPresenter;

    private MiniGameGlobalStateMachine globalStateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(sceneRootPrefab);

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        sceneRoot.Activate();

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter(new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS), viewContainer.GetView<SoundView>());
        soundPresenter.Initialize();

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Initialize();

        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());
        particleEffectPresenter.Initialize();

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        bankPresenter.Initialize();

        storeGalaxyPresenter = new StoreGalaxyPresenter(new StoreGalaxyModel(galaxies));
        storePlanetPresenter = new StorePlanetPresenter(new StorePlanetModel());
        storeShipPresenter = new StoreShipPresenter(new StoreShipModel(ships, bankPresenter));
        storeRocketPresenter = new StoreRocketPresenter(new StoreRocketModel(rockets, bankPresenter));
        storeResourcePresenter = new StoreResourcePresenter(new StoreResourceModel(resources, bankPresenter));

        planetInfoPresenter = new PlanetInfoPresenter(new PlanetInfoModel(), viewContainer.GetView<PlanetInfoView>());

        planetInteractivePresenter = new PlanetInteractivePresenter(new PlanetInteractiveModel(), viewContainer.GetView<PlanetInteractiveView>());

        resourceInteractivePresenter = new ResourceInteractivePresenter(new ResourceInteractiveModel(), viewContainer.GetView<ResourceInteractiveView>());

        resourceInfoPresenter = new ResourceInfoPresenter(new ResourceInfoModel(), viewContainer.GetView<ResourceInfoView>());

        shopShipPresenter = new ShopShipPresenter(new ShopShipModel(), viewContainer.GetView<ShopShipView>());

        shopRocketPresenter = new ShopRocketPresenter(new ShopRocketModel(), viewContainer.GetView<ShopRocketView>());

        planetBuyPresenter = new PlanetBuyPresenter(new PlanetBuyModel(bankPresenter), viewContainer.GetView<PlanetBuyView>());
        rocketBuyPresenter = new RocketBuyPresenter(new RocketBuyModel(prices, bankPresenter), viewContainer.GetView<RocketBuyView>());

        planetRocketUpgradePresenter = new PlanetRocketUpgradePresenter(new PlanetRocketUpgradeModel(upgradeLevelPrices), viewContainer.GetView<PlanetRocketUpgradeView>());

        planetResourcePresenter = new PlanetResourcePresenter(new PlanetResourceModel(), viewContainer.GetView<PlanetResourceView>());

        rocketTransferPresenter = new RocketTransferPresenter(new RocketTransferModel(planetResourcePresenter), viewContainer.GetView<RocketTransferView>());

        planetRocketVisualPresenter = new PlanetRocketVisualPresenter(new PlanetRocketVisualModel(), viewContainer.GetView<PlanetRocketVisualView>());

        globalStateMachine = new MiniGameGlobalStateMachine(sceneRoot, planetInteractivePresenter, planetRocketVisualPresenter);

        ActivateEvents();

        globalStateMachine.Initialize();
        resourceInteractivePresenter.Initialize();
        resourceInfoPresenter.Initialize();
        planetInteractivePresenter.Initialize();
        planetInfoPresenter.Initialize();
        shopShipPresenter.Initialize();
        shopRocketPresenter.Initialize();
        planetBuyPresenter.Initialize();
        rocketBuyPresenter.Initialize();
        planetRocketUpgradePresenter.Initialize();
        rocketTransferPresenter.Initialize();
        planetResourcePresenter.Initialize();
        planetRocketVisualPresenter.Initialize();

        storeRocketPresenter.Initialize();
        storeShipPresenter.Initialize();
        storeResourcePresenter.Initialize();
        storePlanetPresenter.Initialize();
        storeGalaxyPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        storeGalaxyPresenter.OnSelectGalaxy_Value += storePlanetPresenter.SetGalaxy;
        storePlanetPresenter.OnSetPlanets += planetInteractivePresenter.SetPlanets;

        planetInteractivePresenter.OnChooseSecondPlanet += storePlanetPresenter.SelectSecondPlanet;
        planetInteractivePresenter.OnChoosePlanet_Value += storePlanetPresenter.SelectPlanet;
        storePlanetPresenter.OnSelectPlanet_Value += planetInfoPresenter.SetPlanet;

        storeResourcePresenter.OnVisualizeResource += resourceInteractivePresenter.VisualizeResource;
        storeResourcePresenter.OnVisualizeResource += resourceInfoPresenter.VisualizeResource;
        resourceInteractivePresenter.OnChooseResource += storeResourcePresenter.SelectResource;
        storeResourcePresenter.OnSelectResource_Value += resourceInteractivePresenter.SelectResource;
        storeResourcePresenter.OnDeselectResource_Value += resourceInteractivePresenter.DeselectResource;
        resourceInteractivePresenter.OnClickToSaleResource += storeResourcePresenter.SaleSelectResource;

        storeShipPresenter.OnOpenShip += shopShipPresenter.SetOpenShip;
        storeShipPresenter.OnCloseShip += shopShipPresenter.SetCloseShip;
        shopShipPresenter.OnBuyShipShip += storeShipPresenter.BuyShip;

        storeRocketPresenter.OnOpenRocket += shopRocketPresenter.SetOpenRocket;
        storeRocketPresenter.OnCloseRocket += shopRocketPresenter.SetCloseRocket;
        shopRocketPresenter.OnBuyRocket += storeRocketPresenter.BuyRocket;

        storePlanetPresenter.OnSelectClosePlanet_Value += planetBuyPresenter.SetClosePlanet;
        storePlanetPresenter.OnSelectOpenPlanet_Value += planetBuyPresenter.SetOpenPlanet;
        planetBuyPresenter.OnBuyPlanet += storePlanetPresenter.BuyPlanet;
        storePlanetPresenter.OnBuyPlanet_Value += planetInteractivePresenter.Unlock;

        storeRocketPresenter.OnOpenRocket += rocketBuyPresenter.SetRocket;
        storePlanetPresenter.OnSelectClosePlanet_Value += rocketBuyPresenter.SelectClosePlanet;
        storePlanetPresenter.OnSelectRocketPlanet_Value += rocketBuyPresenter.SelectRocketOpenPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Value += rocketBuyPresenter.SelectNoneRocketOpenPlanet;
        rocketBuyPresenter.OnBuyRocket += storePlanetPresenter.BuyRocketToPlanet;

        storePlanetPresenter.OnSelectRocketPlanet_Value += planetRocketUpgradePresenter.SetRocketPlanet;
        storePlanetPresenter.OnSelectClosePlanet_Value += planetRocketUpgradePresenter.SetNoneRocketPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Value += planetRocketUpgradePresenter.SetNoneRocketPlanet;
        planetRocketUpgradePresenter.OnUpgradeCapacity += storePlanetPresenter.UpgradeRocketCapacity;
        planetRocketUpgradePresenter.OnUpgradeSpeed += storePlanetPresenter.UpgradeRocketSpeed;

        storePlanetPresenter.OnSetPlanets += planetResourcePresenter.SetPlanets;
        storePlanetPresenter.OnSelectPlanet_Value += planetResourcePresenter.SelectPlanet;

        storePlanetPresenter.OnBuyRocketToPlanet_Value += rocketTransferPresenter.SetPlanet;
        planetResourcePresenter.OnEndResources += rocketTransferPresenter.ReturnRocketToShip;
        rocketTransferPresenter.OnSendResources += storeResourcePresenter.SendResources;

        sceneRoot.OnClickToOpen_PlanetInfo += storePlanetPresenter.SelectSecondPlanet;
        storePlanetPresenter.OnSelectPlanet_Value += planetRocketVisualPresenter.Select;

        ActivateTransitionEvents();
    }

    private void DeactivateEvents()
    {
        storeGalaxyPresenter.OnSelectGalaxy_Value -= storePlanetPresenter.SetGalaxy;
        storePlanetPresenter.OnSetPlanets -= planetInteractivePresenter.SetPlanets;

        planetInteractivePresenter.OnChooseSecondPlanet -= storePlanetPresenter.SelectSecondPlanet;
        planetInteractivePresenter.OnChoosePlanet_Value -= storePlanetPresenter.SelectPlanet;
        storePlanetPresenter.OnSelectPlanet_Value -= planetInfoPresenter.SetPlanet;

        storeResourcePresenter.OnVisualizeResource -= resourceInteractivePresenter.VisualizeResource;
        storeResourcePresenter.OnVisualizeResource -= resourceInfoPresenter.VisualizeResource;
        resourceInteractivePresenter.OnChooseResource -= storeResourcePresenter.SelectResource;
        storeResourcePresenter.OnSelectResource_Value -= resourceInteractivePresenter.SelectResource;
        storeResourcePresenter.OnDeselectResource_Value -= resourceInteractivePresenter.DeselectResource;

        storeShipPresenter.OnOpenShip -= shopShipPresenter.SetOpenShip;
        storeShipPresenter.OnCloseShip -= shopShipPresenter.SetCloseShip;
        shopShipPresenter.OnBuyShipShip -= storeShipPresenter.BuyShip;

        storeRocketPresenter.OnOpenRocket -= shopRocketPresenter.SetOpenRocket;
        storeRocketPresenter.OnCloseRocket -= shopRocketPresenter.SetCloseRocket;
        shopRocketPresenter.OnBuyRocket -= storeRocketPresenter.BuyRocket;

        storePlanetPresenter.OnSelectClosePlanet_Value -= planetBuyPresenter.SetClosePlanet;
        storePlanetPresenter.OnSelectOpenPlanet_Value -= planetBuyPresenter.SetOpenPlanet;
        planetBuyPresenter.OnBuyPlanet -= storePlanetPresenter.BuyPlanet;
        storePlanetPresenter.OnBuyPlanet_Value -= planetInteractivePresenter.Unlock;

        storeRocketPresenter.OnOpenRocket -= rocketBuyPresenter.SetRocket;
        storePlanetPresenter.OnSelectClosePlanet_Value -= rocketBuyPresenter.SelectClosePlanet;
        storePlanetPresenter.OnSelectRocketPlanet_Value -= rocketBuyPresenter.SelectRocketOpenPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Value -= rocketBuyPresenter.SelectNoneRocketOpenPlanet;
        rocketBuyPresenter.OnBuyRocket -= storePlanetPresenter.BuyRocketToPlanet;

        storePlanetPresenter.OnSelectRocketPlanet_Value -= planetRocketUpgradePresenter.SetRocketPlanet;
        storePlanetPresenter.OnSelectClosePlanet_Value -= planetRocketUpgradePresenter.SetNoneRocketPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Value -= planetRocketUpgradePresenter.SetNoneRocketPlanet;
        planetRocketUpgradePresenter.OnUpgradeCapacity -= storePlanetPresenter.UpgradeRocketCapacity;
        planetRocketUpgradePresenter.OnUpgradeSpeed -= storePlanetPresenter.UpgradeRocketSpeed;

        sceneRoot.OnClickToOpen_PlanetInfo -= storePlanetPresenter.SelectSecondPlanet;
        storePlanetPresenter.OnSelectPlanet_Value -= planetRocketVisualPresenter.Select;

        DeactivateTransitionEvents();
    }

    private void ActivateTransitionEvents()
    {
        storePlanetPresenter.OnSelectPlanet += sceneRoot.OpenPlanetInfoPanel;
        sceneRoot.OnClickToClose_InfoPlanet += sceneRoot.ClosePlanetInfoPanel;

        sceneRoot.OnClickToExit += HandleGoToMainMenu;
    }

    private void DeactivateTransitionEvents()
    {
        storePlanetPresenter.OnSelectPlanet -= sceneRoot.OpenPlanetInfoPanel;
        sceneRoot.OnClickToClose_InfoPlanet -= sceneRoot.ClosePlanetInfoPanel;

        sceneRoot.OnClickToExit -= HandleGoToMainMenu;
    }

    public void Dispose()
    {
        DeactivateEvents();

        sceneRoot?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();

        planetRocketVisualPresenter?.Dispose();
        planetResourcePresenter?.Dispose();
        rocketTransferPresenter?.Dispose();
        planetRocketUpgradePresenter?.Dispose();
        planetBuyPresenter?.Dispose();
        rocketBuyPresenter?.Dispose();
        shopRocketPresenter?.Dispose();
        shopShipPresenter?.Dispose();
        resourceInteractivePresenter?.Dispose();
        resourceInfoPresenter?.Dispose();
        planetInteractivePresenter?.Dispose();
        planetInfoPresenter.Dispose();

        storeRocketPresenter?.Dispose();
        storeShipPresenter?.Dispose();
        storeResourcePresenter.Dispose();
        storePlanetPresenter?.Dispose();
        storeGalaxyPresenter?.Dispose();
        globalStateMachine?.Dispose();
    }

    #region Input

    private void OnDestroy()
    {
        Dispose();
    }

    public event Action OnGoToMainMenu;

    private void HandleGoToMainMenu()
    {
        sceneRoot.Deactivate();
        soundPresenter.Dispose();
        OnGoToMainMenu?.Invoke();
    }

    #endregion
}
