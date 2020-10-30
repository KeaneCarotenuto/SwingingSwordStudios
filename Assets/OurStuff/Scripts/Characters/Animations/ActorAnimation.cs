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

		animator.SetBool("Run", false);
	}	
	
	public void PlaySandboxIdleAnim()
	{
		animator.SetInteger("state", 1);
		animator.SetInteger("combatState", 0);
		animator.SetInteger("sandboxState", 1);

		animator.SetBool("Run", false);
	}

	public void PlayCombatIdleAnim()
	{
		ResetTriggers();
		animator.SetInteger("state", 2);

		animator.SetBool("Run", false);
	}

	void ResetTriggers()
	{
		animator.ResetTrigger("Attack");

		animator.SetBool("Run", false);
	}

	public void PlayAttackAnim()
	{
		// Random Attack Type
		animator.SetBool("Run", false);
		animator.ResetTrigger("Death");
		animator.ResetTrigger("GetHit");
		animator.ResetTrigger("Dodge");

		animator.SetTrigger("Attack");
	}


	public void PlayDeath()
	{
		animator.SetBool("Run", false);

		animator.ResetTrigger("GetHit");
		animator.ResetTrigger("Dodge");
		animator.SetTrigger("Death");
		animator.SetBool("Dead", true);
	}

	public void PlayGetHit()
	{
		animator.SetBool("Run", false);

		animator.ResetTrigger("Death");
		animator.ResetTrigger("Dodge");
		animator.SetTrigger("GetHit");
	}

	public void PlayDodge()
	{
		animator.SetBool("Run", false);

		int random = Random.Range(0, 3);
		animator.ResetTrigger("Death");
		animator.ResetTrigger("GetHit");

		animator.SetInteger("dodgeIndex", random);
		animator.SetTrigger("Dodge");
	}

	public void PlayRunAnim()
	{
		animator.SetBool("Run", true);
	}
}
