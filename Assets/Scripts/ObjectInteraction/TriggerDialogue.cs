using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogue : MonoBehaviour
{
    public UnityEvent Event;

    public void Trigger()
    {
        Event.Invoke();
    }
}
