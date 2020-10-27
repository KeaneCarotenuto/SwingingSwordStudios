using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Register anything that touches this collider
public class En : MonoBehaviour
{
    public GameObject myOwner;
    ActorBehaviour myAi;
    Actor myActor;

    void Start()
    {
        myAi = myOwner.GetComponent<ActorBehaviour>();
        myActor = myOwner.GetComponent<Actor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (myActor.isDead)
        {
            return;
        }

        if (other.tag == "Projectile")
        {
            myAi.CheckForDodging();
        }
    }
}
