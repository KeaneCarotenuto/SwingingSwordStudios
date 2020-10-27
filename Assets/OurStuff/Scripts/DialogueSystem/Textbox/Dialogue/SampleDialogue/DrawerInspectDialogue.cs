using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInspectDialogue : MonoBehaviour
{
    public TextBoxController TBcontroller;
    void Start()
    {
        TBcontroller = GameObject.FindWithTag("TextBoxService").GetComponent<TextBoxController>();
    }
    [SerializeField]
    public List<Sprite> CharSprites = new List<Sprite>();
    // Start is called before the first frame update
    public void Initiate()
    {
        

        TBcontroller.CreateTextBox("...", CharSprites[1]);
        TBcontroller.CreateTextBox("Whats this doing here?", CharSprites[2]);
        TBcontroller.NextTextBox();
        


    }
}
