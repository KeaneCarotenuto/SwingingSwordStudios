using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The text box controller.
/// </summary>

public class TextBoxController : MonoBehaviour
{
    public Queue<GameObject> TextBoxQueue = new Queue<GameObject>();
    public GameObject TBprefab;
    public GameObject Canvas;
    public bool InDialogue;


    /// <summary>
    /// Creates the text box.
    /// </summary>
    /// <param name="_text">The Text.</param>
    /// <param name="_charsprite">The Character Sprite.</param>
    /// <param name="_typespeed">The Type Speed.</param>
    public void CreateTextBox( string _text, Sprite _charsprite = null, float _typespeed = 0.05f)
    {
        Debug.Log(_typespeed);
        GameObject NewTextBox = (GameObject)Instantiate(TBprefab); //Make a new textbox prefab
        Textbox Box = NewTextBox.GetComponent<Textbox>(); //Get the textbox component
        Box.CurrentText = _text; //set the text
        if (_charsprite != null)
        {
            Box.CurrentSprite = _charsprite; //Set the sprite
        }
        Box.TypeSpeed = _typespeed; //Set the typespeed
        NewTextBox.transform.SetParent(Canvas.transform); //Set the parent
        NewTextBox.SetActive(false); //Set it to be inactive
        TextBoxQueue.Enqueue(NewTextBox); //Add it to the queue
    }

    /// <summary>
    /// Moves to the next text box.
    /// </summary>
    public void NextTextBox()
    {
        try
        {
            GameObject NextBox = TextBoxQueue.Dequeue(); //Get the textbox from the front of the queue
            NextBox.SetActive(true); //set it to be aactive
            InDialogue = true;
        }
        catch(Exception e)
        {
            InDialogue = false;
            return;
        }
    }
}
