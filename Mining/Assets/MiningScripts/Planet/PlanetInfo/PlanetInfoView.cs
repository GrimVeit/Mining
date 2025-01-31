using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoView : View
{
    [SerializeField] private TextMeshProUGUI textPlanetName;
    [SerializeField] private Image imagePlanet;

    public void SetPlanet(Planet planet)
    {
        textPlanetName.text = planet.NamePlanet;
        imagePlanet.sprite = planet.PlanetSprite;
    }
}
