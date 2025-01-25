using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPackSpin_MenuScene : IGlobalState
{
    private ClickPresenter clickPresenter;
    private SwipeClickAnimationPresenter swipeClickAnimationPresenter;
    private SwipeClickDescriptionPresenter swipeClickDescriptionPresenter;
    private ISoundProvider soundProvider;
    private IParticleEffectProvider particleEffectProvider;

    private IControlGlobalStateMachine globalMachineControl;

    public EndPackSpin_MenuScene(
        IControlGlobalStateMachine globalMachineControl,
        SwipeClickAnimationPresenter swipeClickAnimationPresenter,
        SwipeClickDescriptionPresenter swipeClickDescriptionPresenter,
        ClickPresenter clickPresenter,
        ISoundProvider soundProvider,
        IParticleEffectProvider particleEffectProvider)
    {
        this.globalMachineControl = globalMachineControl;
        this.swipeClickAnimationPresenter = swipeClickAnimationPresenter;
        this.swipeClickDescriptionPresenter = swipeClickDescriptionPresenter;
        this.clickPresenter = clickPresenter;
        this.soundProvider = soundProvider;
        this.particleEffectProvider = particleEffectProvider;
    }


    public void EnterState()
    {
        Debug.Log("Activate - END PACK SPIN STATE");

        soundProvider.PlayOneShot("NewPack_Presentation");
        particleEffectProvider.Play("NewPack");

        clickPresenter.OnClick += ChangeStateToStartOpenPack;

        swipeClickAnimationPresenter.ActivateAnimation("Click_Spin");
        swipeClickDescriptionPresenter.ActivateDescription("SwipeClick_SpinDescription");
        clickPresenter.Activate("Click_SpinZone");
    }

    public void ExitState()
    {
        Debug.Log("Deactivate - END PACK SPIN STATE");

        clickPresenter.OnClick -= ChangeStateToStartOpenPack;

        swipeClickAnimationPresenter.DeactivateAnimation("Click_Spin");
        swipeClickDescriptionPresenter.DeactivateDescription("SwipeClick_SpinDescription");
        clickPresenter.Deactivate("Click_SpinZone");
    }

    private void ChangeStateToStartOpenPack()
    {
        globalMachineControl.SetState(globalMachineControl.GetState<StartOpenPack_MenuScene>());
    }
}
