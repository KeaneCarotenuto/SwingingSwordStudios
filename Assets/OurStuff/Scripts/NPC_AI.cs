using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_AI : MonoBehaviour
{

    bool bEnabled = true;

    public bool state_combat = false;
    public bool state_scan = false;
    public bool state_reposition = false;
    public bool state_attack = false;


    public bool state_patrol = false;
    public bool state_idle = true;

    public GameObject target;
    public bool bTargetWithinRange = false;

    public GameObject projectile; // Temporary

    Actor myActor;
    NavMeshAgent navAgent;
    GameObject patrolStartPoint;
    GameObject patrolCurrentPoint;
    bool bHasAnim = false;
    ActorAnimation myAnim;
    public void StartCombatState()
    {
        state_combat = true;
    }

    public void EndCombatState()
    {
        state_combat = false;
    }

    public void StartScanState()
    {
        state_scan = true;
        state_reposition = false;
        state_attack = false;
        state_patrol = false;
        state_idle = false;
    }

public void StartRepositionState()
    {
        // Just move around to get within range of their target
        state_scan = false;
        state_reposition = true;
        state_attack = false;
        state_patrol = false;
        state_idle = false;
    }

    public void StartAttackState()
    {
        state_scan = false;
        state_reposition = false;
        state_attack = true;
        state_patrol = false;
        state_idle = false;
    }

    // Non Combat
    public void StartIdleState()
    {
        state_scan = false;
        state_reposition = false;
        state_attack = false;
        state_patrol = false;
        state_idle = true;

        // If this actor is put in the idle state, then turn off combat
        state_combat = false;
    }

    public void StartPatrolState()
    {
        state_scan = false;
        state_reposition = false;
        state_attack = false;
        state_patrol = true;
        state_idle = false;
    }

    private void CheckTargetRange()
    {
        // Check if the target is within range
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < myActor.attackRange)
        {
            // Target is within range!
            bTargetWithinRange = true;
        } else
        {
            // Target is too far
            bTargetWithinRange = false;
        }
    }



    void DoCombatRoutine()
    {
        myActor.moveSpeed = 10;
        transform.LookAt(target.transform.position);
        // Check if i'm within the range of the target
        if (bTargetWithinRange)
        {
            // If I'm within range, start attacking!
            Attack();
        } else
        {
            // I'm not in range, Need to move closer!
            Reposition();
        }
    }

    void DoNormalRoutine()
    {
        myActor.moveSpeed = 5;
        if (state_patrol)
        {
            Patrol();
        } else if (state_idle)
        {
            Idle();
        }
    }

    void Idle()
    {
        // Stand still and do fuck all
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Reposition()
    {
        StartRepositionState();
        // Move to a better position to attack
        navAgent.isStopped = false;
        navAgent.SetDestination(target.transform.position);
    }

    void Attack()
    {
        StartAttackState();
        // Stare at the target
        transform.LookAt(target.transform);
        // Then woop their ass
        myActor.Attack();
        navAgent.isStopped = true;
    }

    void Patrol()
    {
        // Start patrolling, only if there is a waypoint linked to this actor
        navAgent.isStopped = false;
        Vector3 targetPos = patrolCurrentPoint.transform.position;
        navAgent.SetDestination(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance < 5f)
        {
            StartIdleState();
            StartCoroutine("WaitAtPatrolPoint");
        }
    }

    GameObject FindClosestPatrolPoint()
    {
        // WIP, UNTESTED, UNUSED for now. WIll fix later
        PatrolPoint nearestPoint;
        PatrolPoint startPoint = patrolStartPoint.GetComponent<PatrolPoint>();
        float distance = Vector3.Distance(transform.position, startPoint.transform.position);
        float nearestDistance = distance;
        nearestPoint = startPoint;

        // Loop through all the patrol points linkedlist style
        PatrolPoint currentPoint = startPoint.GetNextPoint();
        while(currentPoint != startPoint || currentPoint != null)
        {
            distance = Vector3.Distance(transform.position, currentPoint.transform.position);
            if(distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPoint = currentPoint;
            }
        }
        return nearestPoint.gameObject;
    }

    void Start()
    {
        // First check if this object has an actor class.

        myActor = GetComponent<Actor>();
        if (myActor == null)
        {
            // No actor class! Complain and remove this script from this object.
            //  Debug.Log("ERROR: OBJECT WITH NO ACTOR CLASS HAS BEEN GIVEN AN AI");
            Destroy(this);
        }
        // Set the target as the player for now
        target = GameObject.FindWithTag("Player");
        // Get navmesh agent
        navAgent = GetComponent<NavMeshAgent>();

        if(GetComponent<ActorAnimation>() != null)
        {
            bHasAnim = true;
            myAnim = GetComponent<ActorAnimation>();
        }

        projectile = myActor.projectilePrefab;

        // Find the patrol starting point
        for(int i = 0; i < myActor.linkedObjects.Length; i++)
        {
            if(myActor.linkedObjects[i].tag == "PatrolPoint")
            {
                patrolStartPoint = myActor.linkedObjects[i];
                patrolCurrentPoint = patrolStartPoint;
            }
        }
    }

    void UpdateAnimation()
    {
        if (state_attack || state_idle)
        {
            myAnim.Idle();
        }
        else
        {
            if (state_patrol)
            {
                myAnim.Walk();
            }
            else { 
                myAnim.SprintJump();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bEnabled)
        {
            CheckTargetRange();
            if (state_combat)
            {
                DoCombatRoutine();
            }
            else
            {
                DoNormalRoutine();
            }
            if (bHasAnim)
            {
                UpdateAnimation();
            }
        }

    }

    void SetNextPatrolPoint()
    {
        if (patrolCurrentPoint.GetComponent<PatrolPoint>().GetNextPoint() == null)
        {
            // If it's null, then we reached the end of the patrol points. Go back at the start
            patrolCurrentPoint = patrolStartPoint;
        } else
        {
            patrolCurrentPoint = patrolCurrentPoint.GetComponent<PatrolPoint>().GetNextPoint().gameObject;
        }
    }
    IEnumerator WaitAtPatrolPoint()
    {
        yield return new WaitForSeconds(patrolCurrentPoint.GetComponent<PatrolPoint>().waitTime);   //Wait
        // After the wait, resume patrol and onto the next node
        SetNextPatrolPoint();
        StartPatrolState();
    }
}
