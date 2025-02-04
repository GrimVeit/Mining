using System;
using UnityEngine;

public class MiniGameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Galaxys galaxies;
    [SerializeField] private Ships ships;
    [SerializeField] private Rockets rockets;
    [SerializeField] private RocketBuyLevelPrices prices;
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

    private MiniGameGlobalStateMachine globalStateMachine;

    private void Awake()
    {
        sceneRoot = sceneRootPrefab;
        sceneRoot.Activate();
        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

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

        globalStateMachine = new MiniGameGlobalStateMachine(sceneRoot, planetInteractivePresenter);

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

        storeRocketPresenter.Initialize();
        storeShipPresenter.Initialize();
        storeResourcePresenter.Initialize();
        storePlanetPresenter.Initialize();
        storeGalaxyPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        storeGalaxyPresenter.OnSelectGalaxy += storePlanetPresenter.SetGalaxy;
        storePlanetPresenter.OnSetPlanets += planetInteractivePresenter.SetPlanets;

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
        storePlanetPresenter.OnBuyPlanet_Index += planetInteractivePresenter.Unlock;

        storeRocketPresenter.OnOpenRocket += rocketBuyPresenter.SetRocket;
        storePlanetPresenter.OnSelectClosePlanet_Value += rocketBuyPresenter.SelectClosePlanet;
        storePlanetPresenter.OnSelectRocketPlanet_Index += rocketBuyPresenter.SelectRocketOpenPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Index += rocketBuyPresenter.SelectNoneRocketOpenPlanet;
        rocketBuyPresenter.OnBuyRocket += storePlanetPresenter.BuyRocketToPlanet;

        ActivateTransitionEvents();
    }

    private void DeactivateEvents()
    {
        storeGalaxyPresenter.OnSelectGalaxy -= storePlanetPresenter.SetGalaxy;
        storePlanetPresenter.OnSetPlanets -= planetInteractivePresenter.SetPlanets;

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
        storePlanetPresenter.OnBuyPlanet_Index -= planetInteractivePresenter.Unlock;

        storeRocketPresenter.OnOpenRocket -= rocketBuyPresenter.SetRocket;
        storePlanetPresenter.OnSelectClosePlanet_Value -= rocketBuyPresenter.SelectClosePlanet;
        storePlanetPresenter.OnSelectRocketPlanet_Index -= rocketBuyPresenter.SelectRocketOpenPlanet;
        storePlanetPresenter.OnSelectNoneRocketPlanet_Index -= rocketBuyPresenter.SelectNoneRocketOpenPlanet;
        rocketBuyPresenter.OnBuyRocket -= storePlanetPresenter.BuyRocketToPlanet;

        DeactivateTransitionEvents();
    }

    private void ActivateTransitionEvents()
    {
        storePlanetPresenter.OnSelectPlanet += sceneRoot.OpenPlanetInfoPanel;
        sceneRoot.OnClickToClose_InfoPlanet += sceneRoot.ClosePlanetInfoPanel;
    }

    private void DeactivateTransitionEvents()
    {
        storePlanetPresenter.OnSelectPlanet -= sceneRoot.OpenPlanetInfoPanel;
        sceneRoot.OnClickToClose_InfoPlanet -= sceneRoot.ClosePlanetInfoPanel;
    }

    public void Dispose()
    {
        DeactivateEvents();

        sceneRoot?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();

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

    public event Action OnGoToRestart;

    private void HandleGoToMainMenu()
    {
        sceneRoot.Deactivate();
        soundPresenter.Dispose();
        OnGoToMainMenu?.Invoke();
    }

    #endregion
}
