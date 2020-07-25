using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Parent class of any magic effect scripts in the future. 
    Empty for now.
    No idea how to actually make this work yet
 */
public class MagicEffect : MonoBehaviour
{
    /*--- Variables ---*/
    // Spell Type:
    // 1: Fire and Forget
    // 2: Constant Effect
    // 3: Concentration / Channeling
    bool bEffectStarted;
   // Mag
    
    void Start()
    {
        // AKA, OnMagicEffectStart
       // bEffectStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
