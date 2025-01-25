using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSpin_MenuScene : IGlobalState
{
    private UIMainMenuRoot sceneRoot;
    private ShopItemSelectPresenter shopItemSelectPresenter;
    private UnpackerPackPresenter unpackerPackPresenter;
    private UnpackerCardsPresenter unpackerCardsPresenter;
    private AddCardCollectionPresenter addCardCollectionPresenter;
    private PackSpinPresenter packSpinPresenter;

    private IControlGlobalStateMachine globalMachineControl;

    public PackSpin_MenuScene(
        IControlGlobalStateMachine globalMachineControl,
        UIMainMenuRoot sceneRoot,
        PackSpinPresenter packSpinPresenter,
        ShopItemSelectPresenter shopItemSelectPresenter,
        UnpackerPackPresenter unpackerPackPresenter,
        UnpackerCardsPresenter unpackerCardsPresenter,
        AddCardCollectionPresenter addCardCollectionPresenter)
    {
        this.globalMachineControl = globalMachineControl;
        this.sceneRoot = sceneRoot;
        this.shopItemSelectPresenter = shopItemSelectPresenter;
        this.packSpinPresenter = packSpinPresenter;
        this.unpackerPackPresenter = unpackerPackPresenter;
        this.unpackerCardsPresenter = unpackerCardsPresenter;
        this.addCardCollectionPresenter = addCardCollectionPresenter;
    }


    public void EnterState()
    {
        Debug.Log("Activate - PACK SPIN STATE");

        packSpinPresenter.OnGetPack_DataPack += unpackerPackPresenter.SpawnPack;
        packSpinPresenter.OnGetPack_DataPack += unpackerCardsPresenter.SpawnCards;
        packSpinPresenter.OnGetPack_Pack += shopItemSelectPresenter.SelectPack;

        unpackerCardsPresenter.OnSpawnNewCard += addCardCollectionPresenter.AddCard;

        shopItemSelectPresenter.OnEndSelect += ChangeStateToStartOpenPack;

        sceneRoot.OpenSpinPackPanel();
        packSpinPresenter.Spin();
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - PACK SPIN STATE");

        packSpinPresenter.OnGetPack_DataPack -= unpackerPackPresenter.SpawnPack;
        packSpinPresenter.OnGetPack_DataPack -= unpackerCardsPresenter.SpawnCards;
        packSpinPresenter.OnGetPack_Pack -= shopItemSelectPresenter.SelectPack;

        unpackerCardsPresenter.OnSpawnNewCard -= addCardCollectionPresenter.AddCard;

        shopItemSelectPresenter.OnEndSelect -= ChangeStateToStartOpenPack;
    }

    private void ChangeStateToStartOpenPack()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<EndPackSpin_MenuScene>());
    }
}
