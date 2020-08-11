using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public string waypointID;
    public QuestManager questManager;
    // Start is called before the first frame update
    void Start()
    {
        questManager = GameObject.FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            questManager.OnPlayerAction.Invoke(waypointID, ObjectiveType.GOTO);
            Destroy(gameObject);
        }
    }
}
