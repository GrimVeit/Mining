using System;
using UnityEngine;

public class MiniGameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMiniGameSceneRoot sceneRootPrefab;

    private UIMiniGameSceneRoot sceneRoot;
    private ViewContainer viewContainer;

    private SoundPresenter soundPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private BankPresenter bankPresenter;

    private BasketPresenter basketPresenter;
    private EggCatcherPresenter eggCatcherPresenter;
    private ScorePresenter scorePresenter;
    private PointAnimationPresenter pointAnimationPresenter;
    private TimerPresenter timerPresenter;

    private MiniGameGlobalStateMachine globalStateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = Instantiate(sceneRootPrefab);
        sceneRoot.Activate();
        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

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

        basketPresenter = new BasketPresenter(new BasketModel(3, 1, soundPresenter), viewContainer.GetView<BasketView_LeftRightControl>());
        basketPresenter.Initialize();

        eggCatcherPresenter = new EggCatcherPresenter(new EggCatcherModel(4f, 2f, 0.001f, soundPresenter, particleEffectPresenter), viewContainer.GetView<EggCatcherView>());
        eggCatcherPresenter.Initialize();

        scorePresenter = new ScorePresenter(new ScoreModel(bankPresenter, soundPresenter), viewContainer.GetView<ScoreView>());
        scorePresenter.Initialize();

        pointAnimationPresenter = new PointAnimationPresenter
            (new PointAnimationModel(), 
            viewContainer.GetView<PointAnimationView_BabyChicken>(), 
            soundPresenter);
        pointAnimationPresenter.Initialize();

        timerPresenter = new TimerPresenter(new TimerModel(), viewContainer.GetView<TimerView>());
        timerPresenter.Initialize();

        globalStateMachine = new MiniGameGlobalStateMachine
            (sceneRoot, 
            basketPresenter, 
            eggCatcherPresenter, 
            scorePresenter, 
            pointAnimationPresenter, 
            timerPresenter,
            soundPresenter,
            particleEffectPresenter);
        globalStateMachine.Initialize();

        ActivateEvents();
    }

    private void ActivateEvents()
    {
        sceneRoot.OnGoToMainMenu += HandleGoToMainMenu;
        sceneRoot.OnGoToRestart += HandleGoToRestart;
    }

    private void DeactivateEvents()
    {
        sceneRoot.OnGoToMainMenu -= HandleGoToMainMenu;
        sceneRoot.OnGoToRestart -= HandleGoToRestart;
    }

    public void Dispose()
    {
        DeactivateEvents();

        sceneRoot?.Dispose();
        soundPresenter?.Dispose();
        bankPresenter?.Dispose();
        basketPresenter?.Dispose();
        eggCatcherPresenter?.Dispose();
        particleEffectPresenter?.Dispose();
        eggCatcherPresenter?.Dispose();
        scorePresenter?.Dispose();
        pointAnimationPresenter?.Dispose();
        timerPresenter?.Dispose();

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
        eggCatcherPresenter.DeactivateSpawner();
        sceneRoot.Deactivate();
        sceneRoot.CloseWinPanel();
        sceneRoot.CloseFailPanel();
        soundPresenter.Dispose();
        OnGoToMainMenu?.Invoke();
    }

    private void HandleGoToRestart()
    {
        eggCatcherPresenter.DeactivateSpawner();
        sceneRoot.Deactivate();
        sceneRoot.CloseWinPanel();
        sceneRoot.CloseFailPanel();
        soundPresenter.Dispose();
        OnGoToRestart?.Invoke();
    }

    #endregion
}
