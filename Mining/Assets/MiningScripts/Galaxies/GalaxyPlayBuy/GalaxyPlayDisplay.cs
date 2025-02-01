using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyPlayDisplay : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;

    public void Initialize()
    {
        buttonPlay.onClick.AddListener(()=> OnClickToPlay?.Invoke());
    }

    public void Dispose()
    {
        buttonPlay.onClick.RemoveListener(() => OnClickToPlay?.Invoke());
    }

    public void OpenDisplay()
    {
        buttonPlay.enabled = true;
        buttonPlay.gameObject.SetActive(true);
    }

    public void CloseDisplay()
    {
        buttonPlay.enabled = false;
        buttonPlay.gameObject.SetActive(false);
    }

    #region Input

    public event Action OnClickToPlay;

    #endregion
}
