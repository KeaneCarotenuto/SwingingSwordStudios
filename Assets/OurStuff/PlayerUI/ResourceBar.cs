using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    //Class to be used by each resource bar - hp, mana, stamina
    public Slider slider;

    //Set max value
    public void SetMaxResource(float resource)
    {
        slider.maxValue = resource;
        slider.value = resource;
    }

    //Set current resource
    public void SetResource(float resource)
    {
        slider.value = resource;
    }
}
