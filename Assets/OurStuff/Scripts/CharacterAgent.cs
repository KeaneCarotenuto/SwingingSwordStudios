 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAgent : MonoBehaviour
{
    public GameObject targetDestination;
    NavMeshAgent theAgent;
    // Start is called before the first frame update
    void Start()
    {
        targetDestination = GameObject.FindWithTag("Player");
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(targetDestination.transform.position);
    }
}
