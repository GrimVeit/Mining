using System;
using UnityEngine;

public class MiniGameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Galaxys galaxies;
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

        storeResourcePresenter = new StoreResourcePresenter(new StoreResourceModel(resources, bankPresenter));

        planetInfoPresenter = new PlanetInfoPresenter(new PlanetInfoModel(), viewContainer.GetView<PlanetInfoView>());

        planetInteractivePresenter = new PlanetInteractivePresenter(new PlanetInteractiveModel(), viewContainer.GetView<PlanetInteractiveView>());

        resourceInteractivePresenter = new ResourceInteractivePresenter(new ResourceInteractiveModel(), viewContainer.GetView<ResourceInteractiveView>());

        globalStateMachine = new MiniGameGlobalStateMachine(sceneRoot, planetInteractivePresenter);

        ActivateEvents();

        globalStateMachine.Initialize();
        resourceInteractivePresenter.Initialize();
        planetInteractivePresenter.Initialize();
        planetInfoPresenter.Initialize();
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
        resourceInteractivePresenter.OnChooseResource += storeResourcePresenter.SelectResource;
        storeResourcePresenter.OnSelectResource_Value += resourceInteractivePresenter.SelectResource;
        storeResourcePresenter.OnDeselectResource_Value += resourceInteractivePresenter.DeselectResource;
        resourceInteractivePresenter.OnClickToSaleResource += storeResourcePresenter.SaleSelectResource;

        ActivateTransitionEvents();
    }

    private void DeactivateEvents()
    {
        storeGalaxyPresenter.OnSelectGalaxy -= storePlanetPresenter.SetGalaxy;
        storePlanetPresenter.OnSetPlanets -= planetInteractivePresenter.SetPlanets;

        planetInteractivePresenter.OnChoosePlanet_Value -= storePlanetPresenter.SelectPlanet;
        storePlanetPresenter.OnSelectPlanet_Value -= planetInfoPresenter.SetPlanet;

        storeResourcePresenter.OnVisualizeResource -= resourceInteractivePresenter.VisualizeResource;
        resourceInteractivePresenter.OnChooseResource -= storeResourcePresenter.SelectResource;
        storeResourcePresenter.OnSelectResource_Value -= resourceInteractivePresenter.SelectResource;
        storeResourcePresenter.OnDeselectResource_Value -= resourceInteractivePresenter.DeselectResource;

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

        resourceInteractivePresenter?.Dispose();
        planetInteractivePresenter?.Dispose();
        planetInfoPresenter.Dispose();
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
