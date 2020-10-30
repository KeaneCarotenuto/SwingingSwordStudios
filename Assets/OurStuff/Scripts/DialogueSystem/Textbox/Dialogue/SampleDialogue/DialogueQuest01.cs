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
        if (questManager.GetQuestStage(myQuest.questName) == myStage && !myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Thank you for taking care of that bandit!", Char1Sprite);
            TBcontroller.CreateTextBox("He has been pestering our small town for a while now.", Char1Sprite);
            TBcontroller.CreateTextBox("It was nothing, he got in my way, I dealt with him...", Char2Sprite);
            TBcontroller.CreateTextBox("They have been looking all over the place for them shards that fell during the thunderstorm last night.", Char1Sprite);
            TBcontroller.CreateTextBox("Oh have they now?", Char2Sprite);
            TBcontroller.CreateTextBox("Say, where are these bandits? I might go and have a word with them...", Char2Sprite);
            TBcontroller.CreateTextBox("Here, I'll give you some quests.", Char1Sprite);
            TBcontroller.CreateTextBox("Press 'P' to open up your quest log, and select one to take a look at the objectives.", Char1Sprite);
            questManager.OnPlayerAction.Invoke("OldMan", ObjectiveType.INTERACT);
        } else if (questManager.GetQuestStage(myQuest.questName) != myStage && !myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Hey! Watch out behind you! That bandit over there  is dangerous!", Char1Sprite);
        } else if (myQuest.questComplete)
        {
            TBcontroller.CreateTextBox("Thank you again for taking care of that bandit!", Char1Sprite);
            TBcontroller.CreateTextBox("Remember, press 'p' to open and close your quest log, and select a quest to see what to do next.", Char1Sprite);
        }
        TBcontroller.NextTextBox();
    }
}
