using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeClickDescriptionPresenter
{
    private SwipeClickDescriptionModel model;
    private SwipeClickDescriptionView view;

    public SwipeClickDescriptionPresenter(SwipeClickDescriptionModel model, SwipeClickDescriptionView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        model.OnActivateDescription += view.ActivateDescription;
        model.OnDeactivateDescription += view.DeactivateDescription;
    }

    private void DeactivateEvents()
    {
        model.OnActivateDescription -= view.ActivateDescription;
        model.OnDeactivateDescription -= view.DeactivateDescription;
    }

    #region Input

    public void ActivateDescription(string id)
    {
        model.ActivateDescription(id);
    }

    public void DeactivateDescription(string id)
    {
        model.DeactivateDescription(id);
    }

    #endregion
}
