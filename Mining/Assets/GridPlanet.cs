using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridPlanet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlanetName;

    public void SetData(string name)
    {
        textPlanetName.text = name;
    }
}
