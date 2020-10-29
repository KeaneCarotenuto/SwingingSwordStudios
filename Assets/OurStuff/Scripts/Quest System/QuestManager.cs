using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class QuestEvent : UnityEvent<string, ObjectiveType> { }
public class QuestManager : MonoBehaviour
{
    
    [SerializeField]
    public QuestEvent OnPlayerAction;
    [SerializeField]
    public List<Quest> AllQuests;
    [SerializeField]
    public List<Quest> activeQuests;
    [SerializeField]
    public List<Quest> completedQuests;
    // Start is called before the first frame update
    void Start()
    {
        OnPlayerAction.AddListener(CheckQuestStatus);
        ResetQuests();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetQuests();
        }
    }

    private void ResetQuests()
    {
        foreach (Quest _quest in AllQuests)
        {
            if (_quest != null)
            {
                _quest.currentObjectiveIndex = 0;
                _quest.questComplete = false;

                foreach (questObjective _obj in _quest.objectiveList)
                {
                    _obj.objectiveComplete = false;
                }
            }
           
        }

        //foreach (Quest _quest in completedQuests)
        //{
        //    _quest.currentObjectiveIndex = 0;
        //    _quest.questComplete = false;

        //    foreach (questObjective _obj in _quest.objectiveList)
        //    {
        //        _obj.objectiveComplete = false;
        //    }

        //    activeQuests.Add(_quest);
        //    completedQuests.Remove(_quest);

        //}
    }

    /// <summary>
    /// Checks the quest status.
    /// </summary>
    /// <param name="_targetID">The _target i d.</param>
    /// <param name="_type">The _type.</param>
    void CheckQuestStatus(string _targetID, ObjectiveType _type)
    {
        List<Quest> toCheck = new List<Quest>();
        List<Quest> toRemove =  new List<Quest>();
        List<Quest> toAdd =  new List<Quest>();


        foreach (Quest quest in activeQuests)
        {
            toCheck.Add(quest);
        }

        foreach (Quest quest in toCheck)
        {
            quest.CheckObjective(_targetID, _type);
        }

        foreach (Quest quest in activeQuests)
        {
            //quest.checkObjective(_targetID, _type);
            if (quest.questComplete)
            {
                toAdd.Add(quest);
                toRemove.Add(quest);
            }
        }

        if (toAdd.Count >= 1)
        {
            foreach (Quest quest in toRemove)
            {
                completedQuests.Add(quest);
            }
        }


        if (toRemove.Count >= 1)
        {
            foreach (Quest quest in toRemove)
            {
                activeQuests.Remove(quest);
            }
        }
        
    }

    /// <summary>
    /// Gets the quest stage.
    /// </summary>
    /// <param name="_questName">The _quest name.</param>
    /// <returns>An int.</returns>
    public int GetQuestStage(string _questName)
    {
        foreach (Quest quest in activeQuests)
        {
            if(quest.questName == _questName)
            {
                return quest.currentObjectiveIndex;
            }
            
            
        }
        return 0;
    }
    /// <summary>
    /// Tries to add quest.
    /// </summary>
    /// <param name="_quest">The _quest.</param>
    public void TryAddQuest(Quest _quest)
    {
        if(activeQuests.Contains(_quest) || completedQuests.Contains(_quest))
        {
            return;
        }
        else
        {
            _quest.Initialise();
            activeQuests.Add(_quest);
        }
    }
}
