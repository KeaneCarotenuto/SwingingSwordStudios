using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimation : MonoBehaviour
{
	public Animator animator;
	bool bDoOnce = false;

	void Start()
	{
		animator = GetComponent<Animator>();
		if(animator == null)
		{
			Debug.Log("Error, no animator for this npc");
		}
	}
	public void PlayIdleAnim()
	{
		animator.SetInteger("state", 0);
		animator.SetInteger("combatState", 0);
		animator.SetInteger("sandboxState", 0);
	}	
	
	public void PlaySandboxIdleAnim()
	{
		animator.SetInteger("state", 1);
		animator.SetInteger("combatState", 0);
		animator.SetInteger("sandboxState", 1);
	}

	public void PlayCombatIdleAnim()
	{
		ResetTriggers();
		animator.SetInteger("state", 2);
	}

	void ResetTriggers()
	{
		animator.ResetTrigger("Attack");
	}
	public void PlayAttackAnim()
	{
		// Random Attack Type

		int attackType = Random.Range(0, 2);
		animator.SetInteger("AttackTypeIndex", attackType);
		if(attackType == 0)
		{
			animator.SetInteger("AttackFastIndex", Random.Range(0, 5));
		} else
		{
			animator.SetInteger("AttackMedIndex", Random.Range(0,11));
		}
		
		animator.SetTrigger("Attack");
	}


	public void PlayDeath()
	{
		animator.ResetTrigger("GetHit");
		animator.ResetTrigger("Dodge");
		animator.SetTrigger("Death");
		animator.SetBool("Dead", true);
	}

	public void PlayGetHit()
	{
		animator.ResetTrigger("Death");
		animator.ResetTrigger("Dodge");
		animator.SetTrigger("GetHit");
	}

	public void PlayDodge()
	{
		int random = Random.Range(0, 3);
		animator.ResetTrigger("Death");
		animator.ResetTrigger("GetHit");

		animator.SetInteger("dodgeIndex", random);
		animator.SetTrigger("Dodge");
	}
}
