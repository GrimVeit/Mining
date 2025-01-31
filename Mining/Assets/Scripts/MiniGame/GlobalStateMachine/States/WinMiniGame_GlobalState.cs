using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMiniGame_GlobalState : IGlobalState
{
    private UIMiniGameSceneRoot sceneRoot;
    private EggCatcherPresenter eggCatcherPresenter;
    private PointAnimationPresenter pointAnimationPresenter;
    private IParticleEffectProvider particleEffectProvider;

    private IControlGlobalStateMachine machineControl;

    private ISoundProvider soundProvider;
    private ISound soundGameWin;
    private ISound soundBackground;

    private IEnumerator enumeratorSoundGameOver;

    public WinMiniGame_GlobalState(IControlGlobalStateMachine machineControl, UIMiniGameSceneRoot sceneRoot, EggCatcherPresenter eggCatcherPresenter, PointAnimationPresenter pointAnimationPresenter, ISoundProvider soundProvider, IParticleEffectProvider particleEffectProvider)
    {
        this.machineControl = machineControl;
        this.sceneRoot = sceneRoot;
        this.eggCatcherPresenter = eggCatcherPresenter;
        this.pointAnimationPresenter = pointAnimationPresenter;
        this.soundProvider = soundProvider;

        this.soundGameWin = soundProvider.GetSound("GameWin");
        this.soundBackground = soundProvider.GetSound("Background");
        this.particleEffectProvider = particleEffectProvider;
    }

    public void EnterState()
    {
        eggCatcherPresenter.OnEggDown_Position += pointAnimationPresenter.PlayAnimation;

        //sceneRoot.OpenWinPanel();

        //sceneRoot.CloseFooterPanel();
        //sceneRoot.CloseHeaderPanel();

        soundBackground.SetVolume(0.4f, 0.1f, 0.1f, EndSound);
        particleEffectProvider.Play("GameWin");
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
        soundGameWin.PlayOneShot();

        yield return new WaitForSeconds(2f);

        soundBackground.SetVolume(0.1f, 0.4f, 0.3f);
    }
}
