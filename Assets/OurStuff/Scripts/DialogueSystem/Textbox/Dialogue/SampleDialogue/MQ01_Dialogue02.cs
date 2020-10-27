using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQ01_Dialogue02 : MonoBehaviour
{
    public TextBoxController TBcontroller;
    public Sprite Char1Sprite;
    public Sprite Char2Sprite;
    [SerializeField]
    public List<Sprite> CharSprites = new List<Sprite>();

    // 
    public Quest myQuest;
    public int myStage;
    public string waypointID;
    public GameObject questManagerObj;


    void OnEnable()
    {
        questManagerObj = GameObject.FindWithTag("QuestManager");
        QuestManager questManager = questManagerObj.GetComponent<QuestManager>();
        if (questManager.getQuestStage(myQuest.questName) == myStage)
        {
            TBcontroller.CreateTextBox("I killed those bandits for you", Char2Sprite);
            TBcontroller.CreateTextBox("Excellent! You've done us a great service!", Char1Sprite);
            TBcontroller.CreateTextBox("Here is your reward!", Char1Sprite);
            questManager.OnPlayerAction.Invoke(waypointID, ObjectiveType.INTERACT);
        }
    }
}
