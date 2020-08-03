using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuest01 : MonoBehaviour
{
    public TextBoxController TBcontroller;
    public Sprite Char1Sprite;
    public Sprite Char2Sprite;
    [SerializeField]
    public List<Sprite> CharSprites = new List<Sprite>();

    // 
    public Quest myQuest;
    public int myStage;
    public GameObject questManagerObj;

    void OnEnable()
    {
        questManagerObj = GameObject.FindWithTag("QuestManager");
        QuestManager questManager = questManagerObj.GetComponent<QuestManager>();
        if (questManager.getQuestStage(myQuest.questName) == myStage && !myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Ahh hello there god!", Char1Sprite);
            TBcontroller.CreateTextBox("You've lost your powers? That's rough buddy.", Char1Sprite);
            TBcontroller.CreateTextBox("Got any quest for me?", Char2Sprite);
            TBcontroller.CreateTextBox("Aye. There's a bunch of bandits on that mountain over there.", Char1Sprite);
            TBcontroller.CreateTextBox("Head over there and murder them.", Char1Sprite);
            TBcontroller.CreateTextBox("Return to me when you're done. Cya", Char1Sprite);
        } else if (questManager.getQuestStage(myQuest.questName) != myStage && !myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Hey, have you kicked their asses yet?", Char1Sprite);
        } else if (myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Thank you again!", Char1Sprite);
            TBcontroller.CreateTextBox(":)", Char2Sprite);
        }
    }
}
