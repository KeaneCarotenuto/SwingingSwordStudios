using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorBehaviour : MonoBehaviour
{
    public enum AISandboxActions { IDLE, PATROLLING, TRAVELLING}

    public enum AIStates { SANDBOX, COMBAT, DEAD }
    public enum AICombatActions { HOLD, REPOSITIONING, DODGING, STRAFING, ATTACKING }

    Actor myActor;
    ActorAnimation myAnim;
    NavMeshAgent navAgent;

    /* -- Targets -- */
    GameObject combatTarget;
    GameObject patrolTarget;
    GameObject patrolCurrentTarget;
    GameObject travelTarget;
    GameObject idleTarget;

    public bool bIdleInArea = false;
    // if bIdleInArea is true, then this actor will idle around within x amount of radius of the idleTarget. 
    // If there are idle markers nearby, will use their animation!
    // If that is false, then actor will idle on the idleTarget only. If the idleTarget is an idle marker, play animation!
    public float bIdleRadius = 20f;

    public AISandboxActions sandboxAction;
    public AIStates state;
    public AICombatActions combatAction;

    public bool bAllowCombat = true;
    public bool bAllowSandbox = true;

    public bool bPartyMode = false;

    private float nextDodgeTime;
    public float dodgeCooldown = 1;

    private bool bTargetInRange = false;

    private float attackCooldown;
    /*--- ---*/
    void Start()
    {
        myActor = GetComponent<Actor>();
        myAnim = GetComponent<ActorAnimation>();
        navAgent = GetComponent<NavMeshAgent>();
        combatTarget = GameObject.FindWithTag("Player");// Player for now. TEMP
        state = AIStates.SANDBOX;
        sandboxAction = AISandboxActions.IDLE;
        combatAction = AICombatActions.HOLD;
        nextDodgeTime = Time.time + dodgeCooldown;
        attackCooldown = Time.time + myActor.attackSpeed;
    }

    void Update()
    {
        if (!myActor.isDead)
        {
            if (!bPartyMode)
            {
                EvaluateAI();
            }
            else
            {
                dodgeCooldown = 0.1f;
                myAnim.PlayDodge(Random.Range(1, 5));
            }
        }
    }

    /*--- States ---*/

    public void EnterSandbox()
    {
        sandboxAction = AISandboxActions.IDLE;
    }

    public void EnterCombat()
    {
        if (!bAllowCombat)
        {
            return;
        }

        Debug.Log("ENTER COMBAT");
        myAnim.PlayCombatEnter();
        state = AIStates.COMBAT;
    }


    private void DoSandboxRoutine()
    {
        // Do sandboxing things

        switch (sandboxAction)
        {
            case AISandboxActions.IDLE:
                // Assigned to IDLing. Easy Breazy
                Idle();
                break;
            case AISandboxActions.TRAVELLING:
                // Assigned to travelling to x position
                Travel();
                break;
            case AISandboxActions.PATROLLING:
                // Assigned to patrol job
                Patrol();
                break;
            default:

                break;
        }
    }

    public void CheckForDodging()
    {
        Debug.Log("EYY");
        if (Time.time >= nextDodgeTime)
        {
            nextDodgeTime = Time.time + dodgeCooldown;
            Dodge(Random.Range(1, 5));
        }

    }

    private bool MoveCloserToTarget()
    {
        Debug.Log("Moving closer");
        myAnim.PlayRun(2);
        float distance = Vector3.Distance(combatTarget.transform.position, transform.position);
        navAgent.isStopped = false;
        navAgent.SetDestination(combatTarget.transform.position);
        if(distance <= myActor.attackRange)
        {
            return bTargetInRange = true;
        } else
        {
            return bTargetInRange = false;
        }
    }
    private void DoCombatRoutine()
    {
        // Check if we want to dodge
        // Temporary to check the player only
        //CheckForDodging();
        /* ---- SPAGHETTI CODE ALERT ------*/
        float distance = Vector3.Distance(combatTarget.transform.position, transform.position);
        if(distance > myActor.attackRange)
        {
            combatAction = AICombatActions.HOLD;
        }

        if (combatAction != AICombatActions.ATTACKING)
        {
            if (MoveCloserToTarget())
            {
                PrepareToAttack();
            }
        }
    }

    void PrepareToAttack()
    {
        combatAction = AICombatActions.ATTACKING;
        // Stare at the target
        if (myActor.attackRange > 5)
        {
            transform.LookAt(combatTarget.transform);
        }
        // Then woop their ass
        myActor.Attack();
        navAgent.isStopped = true;
    }

    private void Dodge(int _iDirection)
    {
        // _iDirection
        // 1: Backward, 2: Right, 3: Forward, 4: Left
        myAnim.PlayDodge(_iDirection);
    }

    private void EvaluateAI()
    {
        // What to do!?
        switch (state)
        {
            case AIStates.SANDBOX:
                DoSandboxRoutine();
                break;
            case AIStates.COMBAT:
                Debug.Log("EVALUATE TO COMBAT");
                DoCombatRoutine();
                break;
            default:

                break;
        }
    }

    /*--- MOVEMENT ---*/
    void Patrol()
    {
        navAgent.isStopped = false;
        Vector3 targetPos = patrolCurrentTarget.transform.position;
        navAgent.SetDestination(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance < 5f)
        {
            StartIdle(patrolCurrentTarget);
            StartCoroutine("WaitAtPatrolPoint");
        }
    }

    void SetNextPatrolPoint()
    {
        if (patrolTarget.GetComponent<PatrolPoint>().GetNextPoint() == null)
        {
            // If it's null, then we reached the end of the patrol points. Go back at the start
            patrolCurrentTarget = patrolTarget;
        }
        else
        {
            patrolCurrentTarget = patrolCurrentTarget.GetComponent<PatrolPoint>().GetNextPoint().gameObject;
        }
    }

    void Travel()
    {

    }

    void Idle()
    {

    }

    void Reposition()
    {
        // Move to a better position to attack
        navAgent.isStopped = false;
        navAgent.SetDestination(combatTarget.transform.position);
    }

    /*--- Do Actions ---*/
    public void StartPatrol(GameObject _patrolStartPoint)
    {
        patrolTarget = _patrolStartPoint;
        sandboxAction = AISandboxActions.PATROLLING;
    }

    public void StartIdle(GameObject _idleMarker)
    {

    }
    /*--- Utilities ---*/
    public void ResetAI()
    {
        // Remove all AI Packages, effectively making this actor not do anything
    }

    
    public void ApplyAIPackage(AIPackage _package)
    {
        Debug.Log("APPLYING AI PACKAGE: " + _package.packageName);
        switch (_package.packageType)
        {
            case AIPackage.PackageType.PATROL:
                StartPatrol(_package.target);
                break;
            case AIPackage.PackageType.TRAVEL:

                break;
            case AIPackage.PackageType.IDLE:

                break;
            case AIPackage.PackageType.ATTACK:

                break;
            default:

                break;
        }
    }
    
    // IENumerators
    IEnumerator WaitAtPatrolPoint()
    {
        yield return new WaitForSeconds(patrolCurrentTarget.GetComponent<PatrolPoint>().waitTime);   //Wait
        // After the wait, resume patrol and onto the next node
        SetNextPatrolPoint();
        StartPatrol(patrolCurrentTarget);
    }



}
