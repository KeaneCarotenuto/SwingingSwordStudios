using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void checkObjective(string _targetID, ObjectiveType _type)
    {
        bool completeFlag = true;
        foreach (questObjective objective in objectiveList)
        {

            if (!objective.isComplete())
            {
                if (objective.objectiveIndex <= currentObjectiveIndex)
                {
                    objective.TryAdvance(_targetID, _type);

                }
                if (!objective.isComplete())
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
