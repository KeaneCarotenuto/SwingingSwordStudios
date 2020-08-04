using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue : MonoBehaviour
{
    public TextBoxController TBcontroller;
    public Sprite Char1Sprite;
    public Sprite Char2Sprite;
    [SerializeField]
    public List<Sprite> CharSprites = new List<Sprite>();
    // Start is called before the first frame update
    void OnEnable()
    {
        TBcontroller.CreateTextBox("...", Char1Sprite, 0.02f);
        TBcontroller.CreateTextBox("Huh?", Char2Sprite);
        TBcontroller.CreateTextBox("Who are you?", Char2Sprite);
        TBcontroller.CreateTextBox("...", Char1Sprite);
        TBcontroller.CreateTextBox("Uhh... nevermind.", Char2Sprite);
        TBcontroller.CreateTextBox("I think theres something you could help me with.", Char2Sprite);
        TBcontroller.CreateTextBox("You see that mountain over there?", Char2Sprite);
        TBcontroller.CreateTextBox("Go and climb it and see if you find anything interesting.", Char2Sprite);
        TBcontroller.CreateTextBox("...", Char1Sprite);
        TBcontroller.CreateTextBox("...are you going to say anything?", Char2Sprite);
        TBcontroller.CreateTextBox("...", Char1Sprite);
        TBcontroller.CreateTextBox("Nevermind.", Char2Sprite);




    }
}
