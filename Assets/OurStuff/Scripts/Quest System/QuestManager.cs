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
    public List<Quest> activeQuests;
    [SerializeField]
    public List<Quest> completedQuests;
    // Start is called before the first frame update
    void Start()
    {
        OnPlayerAction.AddListener(CheckQuestStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckQuestStatus(string _targetID, ObjectiveType _type)
    {
        foreach(Quest quest in activeQuests)
        {
            quest.checkObjective(_targetID, _type);
            if(quest.questComplete)
            {
                completedQuests.Add(quest);
                activeQuests.Remove(quest);
            }
        }
    }

    public int getQuestStage(string _questName)
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
