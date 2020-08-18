using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPackageManager : MonoBehaviour
{
    public AIPackage[] aiPackages;
    ActorBehaviour behaviour;

    void Start()
    {
        behaviour = GetComponent<ActorBehaviour>();
    }
    public void AddAIPackage(AIPackage ai)
    {
       // aiPackages
    }

    void Update()
    {
        
    }
}
