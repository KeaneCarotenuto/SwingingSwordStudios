using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// THIS CLASS IS TEMPORARY. DOOM IS ETERNAL
public class QuestTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestManager questManager;
    public string waypointID;
    void Start()
    {
        questManager = GameObject.FindWithTag("QuestManager").GetComponent<QuestManager>();
        
    }
    /// <summary>
    /// Triggers the questmaanager to check if the players action fufills a quest objective.
    /// </summary>
    public void Trigger()
    {
        questManager.OnPlayerAction.Invoke(waypointID, ObjectiveType.KILL);
    }
}
