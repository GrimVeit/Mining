using System;

public class ClickModel
{
    public event Action<string> OnActivateSwipe;
    public event Action<string> OnDeactivateSwipe;

    public event Action OnClick;

    public void Activate(string id)
    {
        OnActivateSwipe?.Invoke(id);
    }

    public void Deactivate(string id)
    {
        OnDeactivateSwipe?.Invoke(id);
    }

    public void Click()
    {
        OnClick?.Invoke();
    }
}
