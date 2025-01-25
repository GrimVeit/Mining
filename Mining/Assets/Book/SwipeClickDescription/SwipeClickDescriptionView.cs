using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwipeClickDescriptionView : View
{
    [SerializeField] private List<SwipeClickDescription> swipeClickDescriptions = new List<SwipeClickDescription>();

    public void ActivateDescription(string id)
    {
        swipeClickDescriptions.FirstOrDefault(data => data.GetID() == id).ActivateDescription();
    }

    public void DeactivateDescription(string id)
    {
        swipeClickDescriptions.FirstOrDefault(data => data.GetID() == id).DeactivateDescription();
    }
}
