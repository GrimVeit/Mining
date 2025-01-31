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

    private StoreGalaxyPresenter galaxyPresenter;
    private GalaxyInfoPresenter galaxyInfoPresenter;
    private GalaxyVisualizePresenter galaxyVisualizePresenter;
    private GalaxyPlayBuyPresenter galaxyPlayBuyPresenter;

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

        galaxyPresenter = new StoreGalaxyPresenter(new StoreGalaxyModel(galaxys));

        galaxyInfoPresenter = new GalaxyInfoPresenter(new GalaxyInfoModel(), viewContainer.GetView<GalaxyInfoView>());

        galaxyVisualizePresenter = new GalaxyVisualizePresenter(new GalaxyVisualizeModel(), viewContainer.GetView<GalaxyVisualizeView>());

        galaxyPlayBuyPresenter = new GalaxyPlayBuyPresenter(new GalaxyPlayBuyModel(bankPresenter), viewContainer.GetView<GalaxyPlayBuyView>());

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        galaxyInfoPresenter.Initialize();
        galaxyVisualizePresenter.Initialize();
        galaxyPresenter.Initialize();
        galaxyPlayBuyPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        galaxyVisualizePresenter.OnChooseGalaxy += galaxyPresenter.SelectGalaxy;

        galaxyPresenter.OnOpenGalaxy += galaxyVisualizePresenter.Unlock;
        galaxyPresenter.OnCloseGalaxy += galaxyVisualizePresenter.Lock;

        galaxyPresenter.OnSelectOpenGalaxy_Value += galaxyVisualizePresenter.Unlock;
        galaxyPresenter.OnSelectCloseGalaxy_Value += galaxyVisualizePresenter.UnlockSelect;
        galaxyPresenter.OnDeselectCloseGalaxy_Value += galaxyVisualizePresenter.Lock;
        galaxyPresenter.OnDeselectOpenGalaxy_Value += galaxyVisualizePresenter.Unlock;

        galaxyPresenter.OnSelectGalaxy += galaxyInfoPresenter.SetGalaxy;

        galaxyPlayBuyPresenter.OnBuyGalaxy += galaxyPresenter.UnlockGalaxy;
        galaxyPresenter.OnSelectOpenGalaxy_Value += galaxyPlayBuyPresenter.SetOpenGalaxy;
        galaxyPresenter.OnSelectCloseGalaxy_Value += galaxyPlayBuyPresenter.SetCloseGalaxy;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        galaxyVisualizePresenter.OnChooseGalaxy -= galaxyPresenter.SelectGalaxy;

        galaxyPresenter.OnOpenGalaxy -= galaxyVisualizePresenter.Unlock;
        galaxyPresenter.OnCloseGalaxy -= galaxyVisualizePresenter.Lock;

        galaxyPresenter.OnSelectOpenGalaxy_Value -= galaxyVisualizePresenter.Unlock;
        galaxyPresenter.OnSelectCloseGalaxy_Value -= galaxyVisualizePresenter.UnlockSelect;
        galaxyPresenter.OnDeselectCloseGalaxy_Value -= galaxyVisualizePresenter.Lock;
        galaxyPresenter.OnDeselectOpenGalaxy_Value -= galaxyVisualizePresenter.Unlock;

        galaxyPresenter.OnSelectGalaxy -= galaxyInfoPresenter.SetGalaxy;

        galaxyPlayBuyPresenter.OnBuyGalaxy -= galaxyPresenter.UnlockGalaxy;
        galaxyPresenter.OnSelectOpenGalaxy_Value -= galaxyPlayBuyPresenter.SetOpenGalaxy;
        galaxyPresenter.OnSelectCloseGalaxy_Value -= galaxyPlayBuyPresenter.SetCloseGalaxy;
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMain += sceneRoot.OpenMainPanel;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToMain -= sceneRoot.OpenMainPanel;
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
        galaxyVisualizePresenter.Dispose();
        galaxyPresenter.Dispose();
        galaxyPlayBuyPresenter.Dispose();
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
