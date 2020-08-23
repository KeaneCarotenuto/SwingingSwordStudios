using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorBehaviour : MonoBehaviour
{
    public enum AICombatActions { IDLE, HOLD, MOVING, STRAFING, ATTACKING, EVADING, DYING, FALLING}
    public enum AISandboxActions { IDLE, DYING}

    public enum AIStates { IDLE, SANDBOX, COMBAT, DEATH, GUARDING, YIELDING, FLEEING }


    public AIStates state;
    AIStates prevState;
    public AICombatActions combatActions;
    public AISandboxActions sandboxActions;

    NavMeshAgent myNavAgent;
    ActorAnimation myAnim;
    Actor myActor;

    GameObject combatTarget;

    float nextDodgeTime;
    float dodgeCooldown = 2;
    void Start()
    {
        ResetAI();
        combatTarget = GameObject.FindWithTag("Player");
        nextDodgeTime = Time.time + dodgeCooldown ;
    }

    public void ResetAI()
    {
        state = AIStates.IDLE;
        combatActions = AICombatActions.IDLE;
        sandboxActions = AISandboxActions.IDLE;

        myActor = GetComponent<Actor>();
        if(myActor == null)
        {
            Debug.Log("An object has actorbehaviourscript but doesn't have an actor script attach! Pls fix");
        }
        myNavAgent = GetComponent<NavMeshAgent>();
        if(myNavAgent == null)
        {
            Debug.Log(myActor.myName + " is missing a navmesh agent!");
        }

        myAnim = GetComponent<ActorAnimation>();
        if(myAnim == null)
        {
            Debug.Log(myActor.myName + " is missing an ActorAnimation Class, please fix");
        }
        myNavAgent.updatePosition = false;
       // myActor 
    }


    public void Update()
    {
        if (!myActor.isDead)
        {
            EvaluateAI();
        }
    }

    private void EvaluateAI()
    {
        switch (state)
        {
            case AIStates.IDLE:
                DoIdleRoutine();
                break;
            case AIStates.SANDBOX:
                DoSandboxRoutine();
                break;
            case AIStates.COMBAT:
                DoCombatRoutine();
                break;
            case AIStates.DEATH:
                DoDeathRoutine();
                break;
            case AIStates.GUARDING:
                DoGuardingRoutine();
                break;
            case AIStates.YIELDING:
                DoYieldingRoutine();
                break;
            case AIStates.FLEEING:
                DoFleeingRoutine();
                break;
            default:
                state = AIStates.IDLE;
                break;
        }
    }

    
    /* -- Routines -- */
    private void DoIdleRoutine()
    {
        myAnim.PlayIdleAnim();
    }

    private void DoSandboxRoutine()
    {
        // Play Enter Idle Animation if first time
        // if (prevState != state)
        //{
        //   myAnim.PlayEnterSandboxAnim();

        // }
        //   prevState = state;
        myAnim.PlaySandboxIdleAnim();
    }

    private void DoCombatRoutine()
    {
        myAnim.PlayCombatIdleAnim();
        switch (combatActions)
        {
            case AICombatActions.ATTACKING:
                DoAttacking();
                break;
        }
    }

    public void EnterCombat()
    {
        state = AIStates.COMBAT;
        combatActions = AICombatActions.ATTACKING;
    }

    public void CheckForDodging()
    {
        if (Time.time >= nextDodgeTime)
        {
            nextDodgeTime = Time.time + dodgeCooldown;
            myAnim.PlayDodge();
        }
    }

    private void DoAttacking()
    {
        Debug.Log("EARE YOU ATTACKING");
        myActor.Attack();
        Vector3 pos = new Vector3();
        pos = combatTarget.transform.position;
        pos.y -= 1f;
        transform.LookAt(pos);
    }

    private void DoDeathRoutine()
    {

    }

    private void DoGuardingRoutine()
    {

    } 

    private void DoYieldingRoutine()
    {

    }

    private void DoFleeingRoutine()
    {

    }
}
