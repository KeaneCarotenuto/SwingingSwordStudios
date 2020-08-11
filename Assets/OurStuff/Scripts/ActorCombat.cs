using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCombat : MonoBehaviour
{
    Actor myActor;
    ActorAnimation myAnim;
   // AttackAbility myAttackAbility;
    void Start()
    {
        myActor = GetComponent<Actor>();
        myAnim = GetComponent<ActorAnimation>();
    }

    void Attack(GameObject _target)
    {
        if(myActor.bCanAttack)
        {
           // myAnim.Attack();
        }
    }
}
