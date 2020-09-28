using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{

    public Text BoxText;
    public Image BoxSprite;
    public Button Bton;

    public string CurrentText;
    public Sprite CurrentSprite;
    public TypeWriter Writer;

    public float TypeSpeed;


    // Start is called before the first frame update
    void Start()
    {
        BoxText.text = CurrentText;
        BoxSprite.sprite = CurrentSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTextBox()
    {
        if (Writer.enabled == true)
        {
            Writer.enabled = false;
            Writer.story = "";
            Writer.Typing = false;
            BoxText.text = CurrentText;
            return;
        }
        else
        {
            FindController F = Bton.GetComponent<FindController>();
            F.TriggerNextBox();
            Destroy(gameObject);
        }
    }
}
