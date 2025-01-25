using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockObject : MonoBehaviour
{
    [SerializeField] private Image imageLock;
    [SerializeField] private Sprite spriteLock;
    [SerializeField] private Sprite spriteSelectLock;

    public void Hide()
    {
        imageLock.gameObject.SetActive(false);
    }

    public void ShowLock()
    {
        imageLock.gameObject.SetActive(true);
        imageLock.sprite = spriteLock;
    }

    public void ShowSelectLock()
    {
        imageLock.gameObject.SetActive(true);
        imageLock.sprite = spriteSelectLock;
    }
}
