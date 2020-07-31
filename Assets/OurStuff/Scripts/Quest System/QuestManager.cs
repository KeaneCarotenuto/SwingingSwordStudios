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
    private List<Quest> activeQuests;
    [SerializeField]
    private List<Quest> completedQuests;
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

    public void TryAddQuest(Quest _quest)
    {
        if(activeQuests.Contains(_quest) || completedQuests.Contains(_quest))
        {
            return;
        }
        else
        {
            activeQuests.Add(_quest);
        }
    }
}
