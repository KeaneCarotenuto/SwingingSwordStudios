////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : ReousrceBar.cs
//--------------------------------------------------------//
//  Description : 
//  Updates UI sliders to values
//  
//  
////////////////////////////////////////////////////////////

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
