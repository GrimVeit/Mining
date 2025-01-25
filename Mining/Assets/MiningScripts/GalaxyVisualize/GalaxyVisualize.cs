using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalaxyVisualize : MonoBehaviour, IPointerClickHandler
{
    public int ID => id;

    public event Action<int> OnChooseGalaxy;

    [SerializeField] private GameObject objectLock;
    [SerializeField] private LockObject lockObject;
    [SerializeField] private Image imageGalaxy;
    [SerializeField] private Sprite spriteLockGalaxy;
    [SerializeField] private Sprite spriteUnlockGalaxy;
    [SerializeField] private Sprite spriteSelectGalaxy;

    private int id;

    public void Initialize(int id)
    {
        this.id = id;
    }

    public void Dispose()
    {

    }

    public void Lock()
    {
        objectLock.SetActive(true);
        imageGalaxy.sprite = spriteLockGalaxy;

        lockObject.ShowLock();
    }

    public void Unlock()
    {
        objectLock.SetActive(false);
        imageGalaxy.sprite = spriteUnlockGalaxy;

        lockObject.Hide();
    }

    public void LockSelect()
    {
        objectLock.SetActive(true);
        imageGalaxy.sprite = spriteSelectGalaxy;

        lockObject.ShowSelectLock();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnChooseGalaxy?.Invoke(id);
    }
}
