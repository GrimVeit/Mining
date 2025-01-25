using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private Cards cards;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private ShopPackPresenter shopPackPresenter;
    private ShopItemSelectPresenter shopItemSelectPresenter;

    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;

    private CardCollectionPresenter cardCollectionPresenter;

    private BookPagesPresenter bookPagesPresenter;

    private SwipeClickAnimationPresenter swipeAnimationPresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;
    private SwipePresenter swipePresenter;
    private ClickPresenter clickPresenter;

    private CardTypeCollectionPresenter cardTypeCollectionPresenter;

    private PackSpinPresenter packSpinPresenter;

    private MenuGlobalStateMachine menuGlobalStateMachine;

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

        bookPagesPresenter = new BookPagesPresenter(new BookPagesModel(soundPresenter), viewContainer.GetView<BookPagesView>());

        cardCollectionPresenter = new CardCollectionPresenter(new CardCollectionModel(cards), viewContainer.GetView<CardCollectionView>());

        unpackerPackPresenter = new UnpackerPackPresenter(new UnpackerPackModel(), viewContainer.GetView<UnpackerPackView>());

        unpackerCardsPresenter = new UnpackerCardsPresenter(new UnpackerCardsModel(cards, cardCollectionPresenter, soundPresenter, particleEffectPresenter), viewContainer.GetView<UnpackerCardsView>());

        addCardCollectionPresenter = new AddCardCollectionPresenter(new AddCardCollectionModel(soundPresenter), viewContainer.GetView<AddCardCollectionView>());

        shopPackPresenter = new ShopPackPresenter(new ShopPackModel(bankPresenter, 20), viewContainer.GetView<ShopPackView>());

        shopItemSelectPresenter = new ShopItemSelectPresenter(new ShopItemSelectModel(soundPresenter), viewContainer.GetView<ShopItemSelectView>());

        packSpinPresenter = new PackSpinPresenter(new PackSpinModel(soundPresenter, particleEffectPresenter), viewContainer.GetView<PackSpinView>());

        swipeAnimationPresenter = new SwipeClickAnimationPresenter(new SwipeClickAnimationModel(), viewContainer.GetView<SwipeClickAnimationView>());

        swipeClickDescriptionPresenter = new SwipeClickDescriptionPresenter(new SwipeClickDescriptionModel(), viewContainer.GetView<SwipeClickDescriptionView>());

        clickPresenter = new ClickPresenter(new ClickModel(), viewContainer.GetView<ClickView>());

        cardTypeCollectionPresenter = new CardTypeCollectionPresenter(new CardTypeCollectionModel(), viewContainer.GetView<CardTypeCollectionView>());

        swipePresenter = new SwipePresenter(new SwipeModel(), viewContainer.GetView<SwipeView>());

        menuGlobalStateMachine = new MenuGlobalStateMachine(
            sceneRoot, 
            shopPackPresenter, 
            shopItemSelectPresenter,
            unpackerPackPresenter, 
            unpackerCardsPresenter,
            bookPagesPresenter,
            packSpinPresenter,
            addCardCollectionPresenter,
            cardCollectionPresenter,
            swipeAnimationPresenter,
            swipePresenter,
            clickPresenter,
            swipeClickDescriptionPresenter,
            soundPresenter,
            particleEffectPresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();


        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        cardTypeCollectionPresenter.Initialize();
        cardCollectionPresenter.Initialize();
        bookPagesPresenter.Initialize();
        unpackerPackPresenter.Initialize();
        unpackerCardsPresenter.Initialize();
        packSpinPresenter.Initialize();
        shopPackPresenter.Initialize();
        shopItemSelectPresenter.Initialize();
        addCardCollectionPresenter.Initialize();
        swipeAnimationPresenter.Initialize();
        swipeClickDescriptionPresenter.Initialize();
        swipePresenter.Initialize();
        clickPresenter.Initialize();

        menuGlobalStateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();

        cardCollectionPresenter.OnOpenCard += cardTypeCollectionPresenter.AddCardType;
        bookPagesPresenter.OnChoosePage_Second += cardTypeCollectionPresenter.OpenDisplay;
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();

        cardCollectionPresenter.OnOpenCard -= cardTypeCollectionPresenter.AddCardType;
        bookPagesPresenter.OnChoosePage_Second -= cardTypeCollectionPresenter.OpenDisplay;
    }

    private void ActivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToGame += HandleGoToGame;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnGoToGame -= HandleGoToGame;
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
        bookPagesPresenter?.Dispose();
        shopItemSelectPresenter?.Dispose();
        shopPackPresenter?.Dispose();
        cardCollectionPresenter?.Dispose();
        packSpinPresenter?.Dispose();
        unpackerPackPresenter?.Dispose();
        swipeAnimationPresenter?.Dispose();
        swipePresenter?.Dispose();
        clickPresenter?.Dispose();
        swipeClickDescriptionPresenter?.Dispose();
        cardTypeCollectionPresenter?.Dispose();
        menuGlobalStateMachine?.Dispose();
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
