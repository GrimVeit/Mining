using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private Galaxys galaxys;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private StoreGalaxyPresenter storeGalaxyPresenter;
    private GalaxyInfoPresenter galaxyInfoPresenter;
    private GalaxyInteractivePresenter galaxyInteractivePresenter;
    private GalaxyPlayBuyPresenter galaxyPlayBuyPresenter;

    private GalaxyVisualPresenter galaxyVisualPresenter;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(menuRootPrefab);
 
        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        storeGalaxyPresenter = new StoreGalaxyPresenter(new StoreGalaxyModel(galaxys));

        galaxyInfoPresenter = new GalaxyInfoPresenter(new GalaxyInfoModel(), viewContainer.GetView<GalaxyInfoView>());

        galaxyInteractivePresenter = new GalaxyInteractivePresenter(new GalaxyInteractiveModel(), viewContainer.GetView<GalaxyInteractiveView>());

        galaxyPlayBuyPresenter = new GalaxyPlayBuyPresenter(new GalaxyPlayBuyModel(bankPresenter), viewContainer.GetView<GalaxyPlayBuyView>());

        galaxyVisualPresenter = new GalaxyVisualPresenter(new GalaxyVisualModel(), viewContainer.GetView<GalaxyVisualView>());

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        galaxyInfoPresenter.Initialize();
        galaxyInteractivePresenter.Initialize();
        storeGalaxyPresenter.Initialize();
        galaxyPlayBuyPresenter.Initialize();
        galaxyVisualPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        galaxyInteractivePresenter.OnChooseGalaxy += storeGalaxyPresenter.SelectGalaxy;

        storeGalaxyPresenter.OnOpenGalaxy += galaxyInteractivePresenter.Unlock;
        storeGalaxyPresenter.OnCloseGalaxy += galaxyInteractivePresenter.Lock;

        storeGalaxyPresenter.OnSelectOpenGalaxy_Value += galaxyInteractivePresenter.Unlock;
        storeGalaxyPresenter.OnSelectCloseGalaxy_Value += galaxyInteractivePresenter.UnlockSelect;
        storeGalaxyPresenter.OnDeselectCloseGalaxy_Value += galaxyInteractivePresenter.Lock;
        storeGalaxyPresenter.OnDeselectOpenGalaxy_Value += galaxyInteractivePresenter.Unlock;

        storeGalaxyPresenter.OnSelectGalaxy_Value += galaxyInfoPresenter.SetGalaxy;

        galaxyPlayBuyPresenter.OnBuyGalaxy += storeGalaxyPresenter.UnlockGalaxy;
        storeGalaxyPresenter.OnSelectOpenGalaxy_Value += galaxyPlayBuyPresenter.SetOpenGalaxy;
        storeGalaxyPresenter.OnSelectCloseGalaxy_Value += galaxyPlayBuyPresenter.SetCloseGalaxy;

        storeGalaxyPresenter.OnSelectGalaxy_Value += galaxyVisualPresenter.Select;
        sceneRoot.OnCloseGalaxyInfoPanel += storeGalaxyPresenter.UnselectGalaxy;
        sceneRoot.OnCloseGalaxyInfoPanel += galaxyVisualPresenter.SelectDefault;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        galaxyInteractivePresenter.OnChooseGalaxy -= storeGalaxyPresenter.SelectGalaxy;

        storeGalaxyPresenter.OnOpenGalaxy -= galaxyInteractivePresenter.Unlock;
        storeGalaxyPresenter.OnCloseGalaxy -= galaxyInteractivePresenter.Lock;

        storeGalaxyPresenter.OnSelectOpenGalaxy_Value -= galaxyInteractivePresenter.Unlock;
        storeGalaxyPresenter.OnSelectCloseGalaxy_Value -= galaxyInteractivePresenter.UnlockSelect;
        storeGalaxyPresenter.OnDeselectCloseGalaxy_Value -= galaxyInteractivePresenter.Lock;
        storeGalaxyPresenter.OnDeselectOpenGalaxy_Value -= galaxyInteractivePresenter.Unlock;

        storeGalaxyPresenter.OnSelectGalaxy_Value -= galaxyInfoPresenter.SetGalaxy;

        galaxyPlayBuyPresenter.OnBuyGalaxy -= storeGalaxyPresenter.UnlockGalaxy;
        storeGalaxyPresenter.OnSelectOpenGalaxy_Value -= galaxyPlayBuyPresenter.SetOpenGalaxy;
        storeGalaxyPresenter.OnSelectCloseGalaxy_Value -= galaxyPlayBuyPresenter.SetCloseGalaxy;

        storeGalaxyPresenter.OnSelectGalaxy_Value -= galaxyVisualPresenter.Select;
        sceneRoot.OnCloseGalaxyInfoPanel -= storeGalaxyPresenter.UnselectGalaxy;
        sceneRoot.OnCloseGalaxyInfoPanel -= galaxyVisualPresenter.SelectDefault;
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMain += sceneRoot.OpenMainPanel;
        storeGalaxyPresenter.OnSelectGalaxy += sceneRoot.OpenGalaxyInfoPanel;
        sceneRoot.OnCloseGalaxyInfoPanel += sceneRoot.CloseGalaxyInfoPanel;

        sceneRoot.OnPlay += HandleGoToGame;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMain -= sceneRoot.OpenMainPanel;
        storeGalaxyPresenter.OnSelectGalaxy -= sceneRoot.OpenGalaxyInfoPanel;
        sceneRoot.OnCloseGalaxyInfoPanel -= sceneRoot.CloseGalaxyInfoPanel;

        sceneRoot.OnPlay -= HandleGoToGame;
    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        soundPresenter?.Dispose();
        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        bankPresenter?.Dispose();

        galaxyInfoPresenter.Dispose();
        galaxyInteractivePresenter.Dispose();
        storeGalaxyPresenter.Dispose();
        galaxyPlayBuyPresenter.Dispose();
        galaxyVisualPresenter.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Input actions

    public event Action OnGoToGame;

    private void HandleGoToGame()
    {
        Deactivate();
        OnGoToGame?.Invoke();
    }

    #endregion
}
