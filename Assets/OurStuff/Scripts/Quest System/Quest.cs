using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : Quest.cs                     
//--------------------------------------------------------//
//  Description : A scriptableobject type containing                                       
//  data for a quest                                                      
//                                                       
//                                                        
//--------------------------------------------------------//
//    Author    : Nerys Thamm BSE20021                           
//--------------------------------------------------------//
//    E-mail    : Nerysthamm@gmail.com                                   
//========================================================//
////////////////////////////////////////////////////////////

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 51)]
public class Quest : ScriptableObject
{
    [SerializeField]
    public string questName;
    [SerializeField]
    public string questDesc;
    [SerializeField]
    public List<questObjective> objectiveList;
    [SerializeField]
    public bool questComplete;
    public int currentObjectiveIndex;
    public Quest nextQuest;

    /// <summary>
    /// Initialises the Quest.
    /// </summary>
    public void Initialise()
    {
        int currentIndex = 0;
        foreach (questObjective objective in objectiveList)
        {
            objective.Initialise();
            objective.objectiveIndex = currentIndex++;
        }
        questComplete = false;
        currentObjectiveIndex = 0;
    }
    /// <summary>
    /// Checks the objective.
    /// </summary>
    /// <param name="_targetID">The target id.</param>
    /// <param name="_type">The type.</param>
    public void CheckObjective(string _targetID, ObjectiveType _type)
    {
        bool completeFlag = true;
        foreach (questObjective objective in objectiveList)
        {

            if (!objective.IsComplete)
            {
                if (objective.objectiveIndex <= currentObjectiveIndex)
                {
                    objective.TryAdvance(_targetID, _type);

                }
                if (!objective.IsComplete)
                {
                    completeFlag = false;
                }
                else { currentObjectiveIndex++; }
            }
        }
        questComplete = completeFlag;

        if (questComplete)
        {
            if (nextQuest != null)
            {
                GameObject.Find("QuestManager").GetComponent<QuestManager>().activeQuests.Add(nextQuest);
            }
            if (questName == "Kill Boss")
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }

    

}
