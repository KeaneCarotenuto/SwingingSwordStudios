using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        if(Inrange == true && !TBcontroller.InDialogue)
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
        if (Input.GetKey(KeyCode.E))
        {
            InvokeKeyPress();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Inrange = true;
            InteractableObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Inrange = false;
            InteractableObject = null;
        }
    }
    private void InvokeKeyPress()
    {
        if (!TBcontroller.InDialogue && InteractableObject != null)
        {
            InteractableObject.GetComponent<TriggerDialogue>().Trigger();

            OnInteract.Invoke();
        }
    }
}
