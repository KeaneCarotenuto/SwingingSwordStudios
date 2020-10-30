////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : QuestWall.cs
//--------------------------------------------------------//
//  Description : 
//  Manages a giant collider wall that stops player progression if they havent completed a quest,
//  And then removes itself if the quest has been completed.
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

public class QuestWall : MonoBehaviour
{
    //The quest that needs to be done
    public Quest questToUnlock;

    //If quest done, del self
    void Update()
    {
        if (questToUnlock.questComplete)
        {
            Destroy(gameObject);
        }
    }
}
