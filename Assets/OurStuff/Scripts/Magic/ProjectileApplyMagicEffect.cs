using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Applies a magic effect on the target object that this thing collides on
    Attach this script to the projectile of the spell that's gonna hit the target. Eg. Bolt from the Lightning spell
     */
public class ProjectileApplyMagicEffect : MonoBehaviour
{
   // public GameObject magicEffectToApply;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Actor actor = other.GetComponent<Actor>();
        if(rb != null && actor != null)
        {
            GameObject obj = other.gameObject;
            ME_Knockback magic = obj.AddComponent<ME_Knockback>() as ME_Knockback;
        }
    }
}
