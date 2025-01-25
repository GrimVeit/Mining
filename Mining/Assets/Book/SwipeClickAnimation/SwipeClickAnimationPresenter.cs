using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeClickAnimationPresenter
{
    private SwipeClickAnimationModel model;
    private SwipeClickAnimationView view;

    public SwipeClickAnimationPresenter(SwipeClickAnimationModel model, SwipeClickAnimationView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        view.Dispose();
    }

    private void ActivateEvents()
    {
        model.OnActivateAnimation += view.ActivateAnimation;
        model.OnDeactivateAnimation += view.DeactivateAnimation;
    }

    private void DeactivateEvents()
    {
        model.OnActivateAnimation -= view.ActivateAnimation;
        model.OnDeactivateAnimation -= view.DeactivateAnimation;
    }

    #region Input

    public void ActivateAnimation(string id)
    {
        model.ActivateAnimation(id);
    }

    public void DeactivateAnimation(string id)
    {
        model.DeactivateAnimation(id);
    }

    #endregion
}
