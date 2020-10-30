using System.Collections;
using System.Collections.Generic;
using UnityEngine;


////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : QuestTarget.cs                     
//--------------------------------------------------------//
//  Description : Designates an npc as a quest target                                       
//   so that killing them fufills a quest objective                                                     
//                                                       
//                                                        
//--------------------------------------------------------//
//    Author    : Nerys Thamm BSE20021                           
//--------------------------------------------------------//
//    E-mail    : Nerysthamm@gmail.com                                   
//========================================================//
////////////////////////////////////////////////////////////
public class QuestTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestManager questManager;
    public string waypointID;
    void Start()
    {
        questManager = GameObject.FindWithTag("QuestManager").GetComponent<QuestManager>();
        
    }
    /// <summary>
    /// Triggers the questmaanager to check if the players action fufills a quest objective.
    /// </summary>
    public void Trigger()
    {
        questManager.OnPlayerAction.Invoke(waypointID, ObjectiveType.KILL);
    }
}
