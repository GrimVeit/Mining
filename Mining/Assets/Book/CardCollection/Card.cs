using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image imageCard;

    public void SetData(Sprite sprite)
    {
        imageCard.sprite = sprite;
    }
}
