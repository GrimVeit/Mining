using System;

public class SwipePresenter
{
    private SwipeModel swipeModel;
    private SwipeView swipeView;

    public SwipePresenter(SwipeModel swipeModel, SwipeView swipeView)
    {
        this.swipeModel = swipeModel;
        this.swipeView = swipeView;
    }

    public void Initialize()
    {
        ActivateEvents();

        swipeView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        swipeView.Dispose();
    }

    private void ActivateEvents()
    {
        swipeView.OnGetDirection += swipeModel.CheckSwipeDirection;

        swipeModel.OnActivateSwipe += swipeView.ActivateSwipe;
        swipeModel.OnDeactivateSwipe += swipeView.DeactivateSwipe;
    }

    private void DeactivateEvents()
    {
        swipeView.OnGetDirection -= swipeModel.CheckSwipeDirection;

        swipeModel.OnActivateSwipe -= swipeView.ActivateSwipe;
        swipeModel.OnDeactivateSwipe -= swipeView.DeactivateSwipe;
    }

    #region Input

    public event Action OnSwipeLeft
    {
        add { swipeModel.OnSwipeLeft += value; }
        remove { swipeModel.OnSwipeLeft -= value; }
    }

    public event Action OnSwipeRight
    {
        add { swipeModel.OnSwipeRight += value; }
        remove { swipeModel.OnSwipeRight -= value; }
    }

    public event Action OnSwipeUp
    {
        add { swipeModel.OnSwipeUp += value; }
        remove { swipeModel.OnSwipeUp -= value; }
    }

    public event Action OnSwipeDown
    {
        add { swipeModel.OnSwipeDown += value; }
        remove { swipeModel.OnSwipeDown -= value; }
    }

    public void Activate(string id)
    {
        swipeModel.Activate(id);
    }

    public void Deactivate(string id)
    {
        swipeModel.Deactivate(id);
    }

    #endregion
}
