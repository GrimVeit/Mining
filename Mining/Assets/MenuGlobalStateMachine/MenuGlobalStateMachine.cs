using System;
using System.Collections.Generic;

public class MenuGlobalStateMachine : IControlGlobalStateMachine
{
    private Dictionary<Type, IGlobalState> states = new Dictionary<Type, IGlobalState>();

    private IGlobalState currentGlobalState;

    public MenuGlobalStateMachine(
        UIMainMenuRoot sceneRoot,
        ShopPackPresenter shopPackPresenter,
        ShopItemSelectPresenter shopItemSelectPresenter,
        UnpackerPackPresenter unpackerPackPresenter,
        UnpackerCardsPresenter unpackerCardsPresenter,
        BookPagesPresenter bookPagesPresenter,
        PackSpinPresenter packSpinPresenter,
        AddCardCollectionPresenter addCardCollectionPresenter,
        CardCollectionPresenter cardCollectionPresenter,
        SwipeClickAnimationPresenter swipeAnimationPresenter,
        SwipePresenter swipePresenter,
        ClickPresenter clickPresenter,
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter,
        ISoundProvider soundProvider,
        IParticleEffectProvider particleEffectProvider) 
    {
        states[typeof(Hello_MenuScene)] = new Hello_MenuScene(this, sceneRoot);
        states[typeof(Main_MenuScene)] = new Main_MenuScene(this, sceneRoot, shopPackPresenter, unpackerPackPresenter, unpackerCardsPresenter, addCardCollectionPresenter);
        states[typeof(PackSpin_MenuScene)] = new PackSpin_MenuScene(this, sceneRoot, packSpinPresenter, shopItemSelectPresenter, unpackerPackPresenter, unpackerCardsPresenter, addCardCollectionPresenter);
        states[typeof(EndPackSpin_MenuScene)] = new EndPackSpin_MenuScene(this, swipeAnimationPresenter, swipeClickDescriptionPresenter, clickPresenter, soundProvider, particleEffectProvider);
        states[typeof(StartOpenPack_MenuScene)] = new StartOpenPack_MenuScene(this, sceneRoot, unpackerPackPresenter, shopItemSelectPresenter, soundProvider);
        states[typeof(OpenPack_MenuScene)] = new OpenPack_MenuScene(this, unpackerPackPresenter, swipeAnimationPresenter, swipeClickDescriptionPresenter, swipePresenter, soundProvider);
        states[typeof(EndOpenPack_MenuScene)] = new EndOpenPack_MenuScene(this, unpackerPackPresenter);
        states[typeof(OpenCards_MenuScene)] = new OpenCards_MenuScene(this, unpackerCardsPresenter, swipeAnimationPresenter, swipePresenter, swipeClickDescriptionPresenter);
        states[typeof(EndOpenCards_MenuScene)] = new EndOpenCards_MenuScene(this, swipeAnimationPresenter, clickPresenter, swipeClickDescriptionPresenter);
        states[typeof(StartOpenBookPage_MenuScene)] = new StartOpenBookPage_MenuScene(this, sceneRoot, addCardCollectionPresenter);
        states[typeof(OpenBookPage_MenuScene)] = new OpenBookPage_MenuScene(this, bookPagesPresenter, addCardCollectionPresenter);
        states[typeof(AddCard_MenuScene)] = new AddCard_MenuScene(this, addCardCollectionPresenter, cardCollectionPresenter, swipeAnimationPresenter, swipeClickDescriptionPresenter, swipePresenter);
        states[typeof(ReadBookPage_MenuScene)] = new ReadBookPage_MenuScene(this, sceneRoot, bookPagesPresenter, swipeAnimationPresenter, swipePresenter, swipeClickDescriptionPresenter);
    }

    public void Initialize()
    {
        SetState(GetState<Hello_MenuScene>());
    }

    public void Dispose()
    {

    }

    public IGlobalState GetState<T>() where T : IGlobalState
    {
        return states[typeof(T)];
    }

    public void SetState(IGlobalState state)
    {
        currentGlobalState?.ExitState();

        currentGlobalState = state;
        currentGlobalState.EnterState();
    }
}
