using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    // Script for a knockback effect. When activated, pushes the target backwards and deal some damage.
    // Reference: https://www.youtube.com/watch?v=i5u6XdQxfcE
 */
public class ME_Knockback : MagicEffect
{
    bool bActive = false;
    public int damage = 25;
    public float magnitude = 15; // Magnitude of the knockback
    public int duration = 10; // Unused
    public int spellType = 1; // Unusedrn
                              //  public  GameObject body; // Temporary. this actor's body, with the rigidbody
    Actor targetActor;
    Transform projectilePosition;
    Rigidbody rb;

    // Temp
    NPC_AI ai;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetActor = GetComponent<Actor>();
        if (GetComponent<NPC_AI>() != null)
        {
            ai = GetComponent<NPC_AI>();
        }
        bActive = true;
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
        //Debug.Log("DEBUG(ME_KNOCKBACK): Knockback triggered!");
        GameObject player = GameObject.FindWithTag("Player");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 direction = transform.position - player.transform.position;
        
        direction.y = direction.y + 5;
        targetActor.TakeDamage(5);
        //  Destroy(gameObject);
        rb.AddForce(direction.normalized * magnitude, ForceMode.Impulse);
        // Disable their AI for a moment
        ai.enabled = false;
        StartCoroutine("Wait");
    }

    void Dispel()
    {
        // Remove this magic effect
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        ai.enabled = true;
    }
    void Update()
    {
        if (bActive)
        {
            bActive = false;
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
    }


    // Waiting. TEmporary
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);   //Wait
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Dispel();
       // Destroy(gameObject);
        
    }
}
