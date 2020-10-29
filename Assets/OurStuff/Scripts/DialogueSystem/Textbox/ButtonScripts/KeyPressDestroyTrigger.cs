using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPressDestroyTrigger : MonoBehaviour
{
    public UnityEvent OnEnterPress;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) //Invoke event when space, enter, or left click are pressed
        { OnEnterPress.Invoke(); }
    }
}
