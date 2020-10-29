using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_QuestUI : MonoBehaviour
{
    public Transform activeQuests, completedQuests, questDetails;
    public GameObject questButton, questPanel;
    public GameObject currentQuestPanel = null;
    public QuestManager questManager;
    /// <summary>
    /// Displays the quest details.
    /// </summary>
    /// <param name="_quest">The _quest.</param>
    public void DisplayQuestDetails(Quest _quest)
    {
        foreach(Transform child in questDetails.transform)
        {
            if(child.gameObject.tag == "DynamicUIElement")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
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

   
}
