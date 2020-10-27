using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindController : MonoBehaviour
{
    GameObject TBservice;
    TextBoxController TBcontroller;
    // Start is called before the first frame update
    void Start()
    {
        TBservice = GameObject.FindGameObjectWithTag("TextBoxService");
        TBcontroller = TBservice.GetComponent<TextBoxController>();

    }
    public void TriggerNextBox()
    {
        TBcontroller.NextTextBox();
    }
    
}
