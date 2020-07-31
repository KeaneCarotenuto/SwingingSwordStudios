using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest", order = 51)]
public class Quest : ScriptableObject
{
    [SerializeField]
    public string questName;
    [SerializeField]
    public string questDesc;
    [SerializeField]
    private List<questObjective> objectiveList;
    [SerializeField]
    public bool questComplete;

    public void Initialise()
    {
        foreach(questObjective objective in objectiveList)
        {
            objective.Initialise();
        }
        questComplete = false;
    }
    public void checkObjective(string _targetID, ObjectiveType _type)
    {
        bool completeFlag = true;
        foreach (questObjective objective in objectiveList)
        {
            if(!objective.isComplete())
            {
                objective.TryAdvance(_targetID, _type);
                if(!objective.isComplete())
                {
                    completeFlag = false;
                }
            }
        }
        questComplete = completeFlag;
    }

}
