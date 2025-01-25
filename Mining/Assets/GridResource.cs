using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridResource : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textResourceName;

    public void SetData(string name)
    {
        textResourceName.text = name;
    }
}
