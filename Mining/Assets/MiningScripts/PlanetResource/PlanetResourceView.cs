using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetResourceView : View
{
    [SerializeField] private TextMeshProUGUI textNameResource;
    [SerializeField] private TextMeshProUGUI textPersentMined;
    [SerializeField] private TextMeshProUGUI textCountMined;

    public void VisualizePlanetResourceData(Planet planet, int countMined, float persentMined)
    {
        textNameResource.text = planet.ResourceType.ToString();
        textCountMined.text = countMined.ToString();
        textPersentMined.text = persentMined.ToString() + "%";
    }
}
