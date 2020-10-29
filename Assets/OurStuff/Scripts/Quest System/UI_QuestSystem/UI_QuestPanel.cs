using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestPanel : MonoBehaviour
{
    public Text questTitleText;
    public Text questDescriptionText;
    public GameObject objectivePrefab;
    public Transform objectivePanel;

    public Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        questTitleText.text = quest.questName;
        questDescriptionText.text = quest.questDesc;
        foreach(questObjective objective in quest.objectiveList)
        {
            GameObject objectiveUI = (GameObject)Instantiate(objectivePrefab);
            UI_Objective uiObjective = objectiveUI.GetComponent<UI_Objective>();
            uiObjective.objectiveDesc = objective.objectiveDesc;
            uiObjective.objectiveComplete = objective.IsComplete;
            objectiveUI.transform.SetParent(objectivePanel);
        }

    }

    
}
