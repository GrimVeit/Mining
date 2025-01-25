using System;

public class ClickPresenter
{
    private ClickModel model;
    private ClickView view;

    public ClickPresenter(ClickModel swipeModel, ClickView swipeView)
    {
        this.model = swipeModel;
        this.view = swipeView;
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
        view.OnClick += model.Click;

        model.OnActivateSwipe += view.ActivateSwipe;
        model.OnDeactivateSwipe += view.DeactivateSwipe;
    }

    private void DeactivateEvents()
    {
        view.OnClick -= model.Click;

        model.OnActivateSwipe -= view.ActivateSwipe;
        model.OnDeactivateSwipe -= view.DeactivateSwipe;
    }

    #region Input

    public event Action OnClick
    {
        add { model.OnClick += value; }
        remove { model.OnClick -= value; }
    }

    public void Activate(string id)
    {
        model.Activate(id);
    }

    public void Deactivate(string id)
    {
        model.Deactivate(id);
    }

    #endregion
}
