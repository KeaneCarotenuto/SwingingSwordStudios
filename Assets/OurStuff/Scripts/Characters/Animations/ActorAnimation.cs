using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimation : MonoBehaviour
{
	public Animator animator;
	public bool bIsInCombat = false;

	public bool testDodge = false;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (bIsInCombat)
		{
			PlayCombatEnter();
		} else
		{
			PlaySandboxIdle();
		}

		if(testDodge)
		{
			testDodge = false;
			int random = Random.Range(1, 5);
			PlayDodge(random);
		}
	}

	void StartCombat()
	{
		bIsInCombat = true;
		animator.SetInteger("iCombatState", 1);
	}

	void ResetToSandbox()
	{
		animator.SetBool("isInCombat", false);
		animator.SetInteger("iCombatState", 0);
	}
	public void PlaySandboxIdle()
	{
		ResetToSandbox();
	}

	public void PlayCombatEnter()
	{
		animator.SetBool("isInCombat", true);
		animator.SetInteger("iCombatState", 1);
	}

	public void PlayDodge(int _iDirection)
	{
		if(_iDirection > 5 || _iDirection < 1)
		{
			_iDirection = 1;
		}
		animator.SetInteger("DodgeDirection", _iDirection);
		animator.SetTrigger("isDodging");
	}

	void ResetAnimations()
	{
		animator.SetBool("isRunning", false);
	}
	void ResetTriggers()
	{
		animator.ResetTrigger("isDodging");
		animator.ResetTrigger("Death");
		animator.ResetTrigger("Attack");
		animator.ResetTrigger("GetHit");
		
	}
	public void PlayDeath()
	{
		int random = Random.Range(0, 6);
		ResetTriggers();
		animator.SetInteger("deathIndex", random);
		animator.SetTrigger("Death");
		animator.SetBool("isDead", true);
	}

	public void PlayAttack()
	{
		ResetAnimations();
		int random = Random.Range(0, 3);
		ResetTriggers();
		animator.SetInteger("attackType", random);
		animator.SetTrigger("Attack");
	}

	public void PlayGetHit()
	{
		ResetTriggers();
		ResetAnimations();
		animator.SetTrigger("GetHit");
	}

	public void PlayRun(int _iType)
	{
		// 1 Normal Run
		// 2 Combat Run
		ResetTriggers();
		ResetAnimations();
		animator.SetBool("isRunning", true);
		switch (_iType)
		{
			case 1:
				break;
			case 2:
				bIsInCombat = true;
				animator.SetInteger("iCombatState", 1);
				break;
			default:
				break;
		}
	}
}
