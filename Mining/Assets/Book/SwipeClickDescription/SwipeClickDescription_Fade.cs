using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwipeClickDescription_Fade : SwipeClickDescription
{
    public override string GetID() => id;

    [SerializeField] private string id;
    [SerializeField] private Transform transformParent;
    [SerializeField] private Transform transformPosition;
    [SerializeField] private Description descriptionPrefab;

    private Description currentDescription;

    public override void ActivateDescription()
    {
        if(currentDescription != null)
        {
            Destroy(currentDescription.gameObject);
        }

        currentDescription = Instantiate(descriptionPrefab, transformParent);
        currentDescription.SetScale(Vector3.zero);
        currentDescription.transform.position = transformPosition.position;
        currentDescription.ScaleTo(Vector3.one, 0.2f);
    }

    public override void DeactivateDescription()
    {
        if (currentDescription == null) return;

        currentDescription.ScaleTo(Vector3.zero, 0.2f, currentDescription.Destroy);
    }
}
