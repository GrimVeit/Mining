using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeShip : MonoBehaviour
{
    public int ID => int.Parse(CurrentShip.GetID());

    [SerializeField] private TextMeshProUGUI textNameShip;
    [SerializeField] private Image imageShip;
    [SerializeField] private Image imageFrame;
    [SerializeField] private Sprite spriteFrameSelect;
    [SerializeField] private Sprite spriteFrameDeselect;
    [SerializeField] private Button buttonTakeShip;
    [SerializeField] private GameObject objectSelect;

    public Ship CurrentShip { get; private set; }

    public void Initialize()
    {
        buttonTakeShip.onClick.AddListener(() => OnTakeShip?.Invoke(int.Parse(CurrentShip.GetID())));
    }

    public void SetData(Ship ship)
    {
        this.CurrentShip = ship;

        textNameShip.text = ship.Name.ToUpper();
        imageShip.sprite = ship.Sprite;
    }

    public void Dispose()
    {
        buttonTakeShip.onClick.RemoveListener(() => OnTakeShip?.Invoke(int.Parse(CurrentShip.GetID())));
    }

    public void SelectShip()
    {
        imageFrame.sprite = spriteFrameDeselect;
        buttonTakeShip.gameObject.SetActive(false);
        objectSelect.SetActive(true);
    }

    public void UnselectShip()
    {
        imageFrame.sprite = spriteFrameSelect;
        buttonTakeShip.gameObject.SetActive(true);
        objectSelect.SetActive(false);
    }

    #region Input

    public event Action<int> OnTakeShip;

    #endregion
}
