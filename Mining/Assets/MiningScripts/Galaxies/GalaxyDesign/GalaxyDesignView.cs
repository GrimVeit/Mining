using UnityEngine;
using UnityEngine.UI;

public class GalaxyDesignView : View
{
    [SerializeField] private Image imageBackground;

    public void SetGalaxy(Galaxy galaxy)
    {
        imageBackground.sprite = galaxy.Sprite;
    }
}
