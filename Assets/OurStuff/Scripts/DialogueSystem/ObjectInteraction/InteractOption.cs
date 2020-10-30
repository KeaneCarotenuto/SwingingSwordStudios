using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : InteractOption.cs                     
//--------------------------------------------------------//
//  Description : Allows the player to trigger interaction                                       
//  scripts on NPCs and objects in the world                                                      
//                                                       
//                                                        
//--------------------------------------------------------//
//    Author    : Nerys Thamm BSE20021                           
//--------------------------------------------------------//
//    E-mail    : NerysThamm@gmail.com                                  
//========================================================//
////////////////////////////////////////////////////////////
public class InteractOption : MonoBehaviour
{
    bool Inrange;
    public GameObject InteractPrompt;
    public GameObject InteractableObject;
    public UnityEvent OnInteract;
    public TextBoxController TBcontroller;
    


    // Start is called before the first frame update
    void Start()
    {
        TBcontroller = GameObject.FindWithTag("TextBoxService").GetComponent<TextBoxController>();
        Inrange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Inrange == true && !TBcontroller.InDialogue)  //Dispay the prompt if the player is in range and not currently in dialogue
        {
            InteractPrompt.SetActive(true);
            
        }
        else
        {
            if (InteractPrompt != null)
            {
                InteractPrompt.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.E)) //Invoke the event on E press
        {
            InvokeKeyPress();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable") //Checks of the object is interactible, if so, stores it and lets the script know that an object is in range
        {
            Inrange = true;
            InteractableObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision) //Removes the object from storage and lets the script know it moved out of range
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Inrange = false;
            InteractableObject = null;
        }
    }
    private void InvokeKeyPress() //Trigger the scripts on the interactible object
    {
        if (!TBcontroller.InDialogue && InteractableObject != null)
        {
            InteractableObject.GetComponent<TriggerDialogue>().Trigger();

            OnInteract.Invoke();
        }
    }
}
