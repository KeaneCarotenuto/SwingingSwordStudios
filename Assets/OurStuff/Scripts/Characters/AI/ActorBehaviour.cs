using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    This script is attached to NPCs. Allows them to have basic AI such as 
    1) Idle - Wander Around Randomly
    2) Following - They follow a target
    3) Fleeing - Flee from selected targets
    4) Attacking - Attack a target
    5) Alert - Will be triggered if enemies gets within range.

 */

public class ActorBehaviour : MonoBehaviour
{
    /*
    // Guarding 
    public float fGuardRadius = 10f;
    // ACtors/Objects nearby
    Collider[] nearbyObjects;
    Transform target;
    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nearbyObjects = Physics.OverlapSphere(this.transform.position, fGuardRadius);
        if(checkForEnemyNearby())
        {
            // There's an enemy, follow the nearest one
            Debug.Log("ALERT!");
        }
    }

    bool checkForEnemyNearby()
    {
        // Is there an enemy nearby?
        Debug.Log("Colliders Count: " + nearbyObjects.Length);
        for(int i = 0; i < nearbyObjects.Length; i++)
        {
            Actor otherActor = nearbyObjects[i].gameObject.GetComponent<Actor>();
            Actor myActor = GetComponent<Actor>();
            if (otherActor != null) ;
            {
                // This object is an actor, check if that actor is an enemy
                if (otherActor.IsInEnemyFaction(myActor.myFaction.EnemyFactions)) {
                    // This actor is an enemy, return true
                    return true;
                } // Else, not an enemy. Ignore
                return false;
            }  // Else, it's not an actor, skip!
            return false;
        }
        return false;
    }

    private Transform GetNearestEnemy()
    {
        ///Transform nearest;
        return this.transform;
        
    }


    void OnDrawGizmosSelected()
    {
        // Displays the guard range of this pawn when looking at the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fGuardRadius);
    }
    */
}
