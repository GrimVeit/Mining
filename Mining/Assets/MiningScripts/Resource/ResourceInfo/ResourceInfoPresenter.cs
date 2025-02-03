public class ResourceInfoPresenter
{
    private ResourceInfoModel model;
    private ResourceInfoView view;

    public ResourceInfoPresenter(ResourceInfoModel model, ResourceInfoView view)
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
        model.OnVisualizeResource += view.VisualizeResource;
    }

    private void DeactivateEvents()
    {
        model.OnVisualizeResource -= view.VisualizeResource;
    }

    #region Input

    public void VisualizeResource(Resource resource)
    {
        model.VisualizeResource(resource);
    }

    #endregion
}
