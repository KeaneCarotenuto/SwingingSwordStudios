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
		animator.SetInteger("DodgeDirection", _iDirection);
		animator.SetTrigger("isDodging");
	}
}
