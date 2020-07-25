using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    // Script for a knockback effect. When activated, pushes the target backwards and deal some damage.
    // Reference: https://www.youtube.com/watch?v=i5u6XdQxfcE
 */
public class ME_Knockback : MagicEffect
{
    public int damage = 25;
    public float magnitude = 25; // Magnitude of the knockback
    public int duration = 10; // Unused
    public int spellType = 1; // Unusedrn
                              //  public  GameObject body; // Temporary. this actor's body, with the rigidbody
    Actor targetActor;
    Transform targetTransform;
    Vector3 targetPosition;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetActor = GetComponent<Actor>();
        targetTransform = gameObject.transform;
        targetPosition = targetTransform.position;
        if (targetActor == null)
        {
         //   Debug.Log("DEBUG(ME_KNOCKBACK): This magic effect either not attached to an actor OR you didn't put an ACTOR class to the target npc");
            Dispel();
        }
        if (rb == null)
        {
         //   Debug.Log("DEBUG(ME_KNOCKBACK): NO Rigidbody detected on the target");
            Dispel();
        }
        // InvokeRepeating("Knockback", 0, 8);
    }

    void Knockback()
    {
        targetTransform = gameObject.transform;
        targetPosition = targetTransform.position;
        //Debug.Log("DEBUG(ME_KNOCKBACK): Knockback triggered!");
        Vector3 direction = targetPosition - targetTransform.forward;
        direction.y = direction.y + 5;
        targetActor.TakeDamage(10);
        //  Destroy(gameObject);
        rb.AddForce(direction.normalized * magnitude, ForceMode.Impulse);
        StartCoroutine(Wait(0.5f));
    }

    void Dispel()
    {
        // Remove this magic effect
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Destroy(this);
    }
    void Update()
    {
        Knockback();
        if (spellType == 1)
        {
            // If this spell is a fire and forget, trigger once then remove
            Dispel();
        }
        else if (spellType == 2)
        {
            // If this spell is constant effect, trigger for set amount of duration.
        }
        else if (spellType == 3)
        {
            // If this is a channeling spell, ???
        }
        else
        {
            // Out of bounds.
        }
    }


    // Waiting. TEmporary
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
    }
}
