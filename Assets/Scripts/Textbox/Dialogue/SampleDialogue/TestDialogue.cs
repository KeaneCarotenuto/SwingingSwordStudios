using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public TextBoxController TBcontroller;
    public Sprite Char1Sprite;
    public Sprite Char2Sprite;
    [SerializeField]
    public List<Sprite> CharSprites = new List<Sprite>();
    // Start is called before the first frame update
    void OnEnable()
    {
        TBcontroller.CreateTextBox( "Hello, this is a test of the text box system, please press the arrow to continue.", Char1Sprite);
        TBcontroller.CreateTextBox( "You can also use the Spacebar or Enter key to continue, please try this now.", Char1Sprite);
        TBcontroller.CreateTextBox( "Good! Now, you should notice that the text is typing out instead of appearing all at once.", Char1Sprite);
        TBcontroller.CreateTextBox( "We will now test the multiple Character Dialogue system.", Char1Sprite);
        TBcontroller.CreateTextBox("This would now be a seperate character speaking.", Char2Sprite);
        TBcontroller.CreateTextBox( "Now this character is speaking at a type speed of 0.1f", Char2Sprite, 0.1f);
        TBcontroller.CreateTextBox("Now this character is speaking at a type speed of 0.001f", Char2Sprite, 0.001f);
        TBcontroller.CreateTextBox("As you can see, the same character can speak again.", Char2Sprite);
        TBcontroller.CreateTextBox("Now the First character is speaking again.", Char1Sprite);
        TBcontroller.CreateTextBox( "The test is now complete.", Char1Sprite);

        
        

    }

    
}
