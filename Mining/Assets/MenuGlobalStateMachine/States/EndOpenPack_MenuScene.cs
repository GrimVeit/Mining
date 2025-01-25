using UnityEngine;

public class EndOpenPack_MenuScene : IGlobalState
{
    private UnpackerPackPresenter unpackerPackPresenter;

    private IControlGlobalStateMachine controlGlobalStateMachine;

    public EndOpenPack_MenuScene(
        IControlGlobalStateMachine controlGlobalStateMachine,
        UnpackerPackPresenter unpackerPackPresenter)
    {
        this.controlGlobalStateMachine = controlGlobalStateMachine;
        this.unpackerPackPresenter = unpackerPackPresenter;
    }

    public void EnterState()
    {
        Debug.Log("Activate - END OPEN PACK STATE");

        unpackerPackPresenter.OnClosePack += ChangeStateToOpenCards;
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - END OPEN PACK STATE");

        unpackerPackPresenter.OnClosePack -= ChangeStateToOpenCards;
    }

    private void ChangeStateToOpenCards()
    {
        controlGlobalStateMachine.SetState(controlGlobalStateMachine.GetState<OpenCards_MenuScene>());
    }
}
