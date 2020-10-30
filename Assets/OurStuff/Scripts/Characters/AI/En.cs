////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  :  En.cs                                  //
//--------------------------------------------------------//
//  Description : Simple script that detects nearby       //
//               objects to the npc this is attached to   //
//                                                        //
//                                                        //
//--------------------------------------------------------//
//    Author    : Sem Jafet Salgo BSE20021                //
//--------------------------------------------------------//
//    E-mail    : sjafetsalgo15@gmail.com                 //
//========================================================//
////////////////////////////////////////////////////////////


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
