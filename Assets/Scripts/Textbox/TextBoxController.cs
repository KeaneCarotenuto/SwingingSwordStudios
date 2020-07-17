using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextBoxController : MonoBehaviour
{
    public Queue<GameObject> TextBoxQueue = new Queue<GameObject>();
    public GameObject TBprefab;
    public GameObject Canvas;
    public bool InDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTextBox( string _text, Sprite _charsprite = null, float _typespeed = 0.05f)
    {
        Debug.Log(_typespeed);
        GameObject NewTextBox = (GameObject)Instantiate(TBprefab);
        Textbox Box = NewTextBox.GetComponent<Textbox>();
        Box.CurrentText = _text;
        if (_charsprite != null)
        {
            Box.CurrentSprite = _charsprite;
        }
        Box.TypeSpeed = _typespeed;
        NewTextBox.transform.SetParent(Canvas.transform);
        NewTextBox.SetActive(false);
        TextBoxQueue.Enqueue(NewTextBox);
    }

    public void NextTextBox()
    {
        try
        {
            GameObject NextBox = TextBoxQueue.Dequeue();
            NextBox.SetActive(true);
            InDialogue = true;
        }
        catch(Exception e)
        {
            InDialogue = false;
            return;
        }
    }
}
