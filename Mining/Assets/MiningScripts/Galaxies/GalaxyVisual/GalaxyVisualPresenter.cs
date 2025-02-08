using UnityEngine;

public class GalaxyVisualPresenter
{
    private readonly GalaxyVisualModel model;
    private readonly GalaxyVisualView view;

    public GalaxyVisualPresenter(GalaxyVisualModel model, GalaxyVisualView view)
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
        model.OnSelect += view.Select;
        model.OnSelectDefault += view.SelectDefault;
    }

    private void DeactivateEvents()
    {
        model.OnSelect -= view.Select;
        model.OnSelectDefault -= view.SelectDefault;
    }

    #region Input

    public void Select(Galaxy galaxy)
    {
        model.Select(int.Parse(galaxy.GetID()));
    }

    public void SelectDefault()
    {
        model.SelectDefault();
    }

    #endregion
}
