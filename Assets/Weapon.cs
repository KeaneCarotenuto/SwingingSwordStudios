////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : Wepaons.cs
//--------------------------------------------------------//
//  Description : 
//  This with this script deal damage to the player on contact
//  
//  
//--------------------------------------------------------//
//    Author    : Keane Carotenuto BSE20021               //
//--------------------------------------------------------//
//    E-mail    : KeaneCarotenuto@gmail.com               //
//========================================================//
////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //If touches player, deal damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            other.GetComponent<PlayerScript>().health -= 10;
        }
    }
}
