using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuestUI : MonoBehaviour
{
    public Transform activeQuests, completedQuests, questDetails;
    public GameObject questButton, questPanel;
    public GameObject currentQuestPanel = null;
    public QuestManager questManager;
    public void DisplayQuestDetails(Quest _quest)
    {
        
        currentQuestPanel = (GameObject)Instantiate(questPanel);
        UI_QuestPanel panel = currentQuestPanel.GetComponent<UI_QuestPanel>();
        panel.quest = _quest;
        currentQuestPanel.transform.SetParent(questDetails);
    }
    // Start is called before the first frame update
    void Awake()
    {
        questManager = FindObjectOfType<QuestManager>();
        foreach(Quest quest in questManager.activeQuests)
        {
            GameObject button = (GameObject)Instantiate(questButton);
            button.GetComponent<UI_QuestButton>().quest = quest;
            button.transform.parent = activeQuests;
        }
        foreach (Quest quest in questManager.completedQuests)
        {
            GameObject button = (GameObject)Instantiate(questButton);
            button.GetComponent<UI_QuestButton>().quest = quest;
            button.transform.parent = completedQuests;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
