using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestButton : MonoBehaviour
{
    public Text buttonText;
    public Quest quest;
    public UI_QuestUI questUI;
    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = quest.questName;
        questUI = GetComponentInParent<UI_QuestUI>();
    }

    /// <summary>
    /// Displays the details.
    /// </summary>
    public void DisplayDetails()
    {
        Debug.Log("Clicked " + quest.name);
        questUI.DisplayQuestDetails(quest);
    }

    
}
