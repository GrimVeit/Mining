using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailMiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private EggCatcherPresenter eggCatcherPresenter;
    private PointAnimationPresenter pointAnimationPresenter;
    private ISoundProvider soundProvider;
    private ISound soundBackground;
    private ISound soundGameOver;

    private IControlGlobalStateMachine machineControl;

    private IEnumerator enumeratorSoundGameOver;

    public FailMiniGame_GlobalState(IControlGlobalStateMachine machineControl, UIMiniGameSceneRoot sceneRoot, EggCatcherPresenter eggCatcherPresenter, PointAnimationPresenter pointAnimationPresenter, ISoundProvider soundProvider)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
        this.eggCatcherPresenter = eggCatcherPresenter;
        this.pointAnimationPresenter = pointAnimationPresenter;
        this.soundProvider = soundProvider;

        this.soundGameOver = soundProvider.GetSound("GameOver");
        this.soundBackground = soundProvider.GetSound("Background");
    }

    public void EnterState()
    {
        eggCatcherPresenter.OnEggDown_Position += pointAnimationPresenter.PlayAnimation;

        //sceneRoot.OpenFailPanel();

        //sceneRoot.CloseFooterPanel();
        //sceneRoot.CloseHeaderPanel();

        soundBackground.SetVolume(0.4f, 0.1f, 0.1f, EndSound);
    }

    public void ExitState()
    {
        if (enumeratorSoundGameOver != null)
            Coroutines.Stop(enumeratorSoundGameOver);

        eggCatcherPresenter.OnEggDown_Position -= pointAnimationPresenter.PlayAnimation;
    }

    private void EndSound()
    {
        if (enumeratorSoundGameOver != null)
            Coroutines.Stop(enumeratorSoundGameOver);

        enumeratorSoundGameOver = EndSoundGameOver();
        Coroutines.Start(enumeratorSoundGameOver);
    }

    private IEnumerator EndSoundGameOver()
    {
        soundGameOver.PlayOneShot();

        yield return new WaitForSeconds(2f);

        soundBackground.SetVolume(0.1f, 0.4f, 0.4f);
    }
}
