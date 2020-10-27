using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType
{
    KILL,
    GOTO,
    INTERACT
}
[CreateAssetMenu(fileName = "New Objective", menuName = "Objective", order = 51)]
public class questObjective : ScriptableObject
{
    [SerializeField]
    public int defaultObjectiveAmount;
    private int objectiveAmount;
    [SerializeField]
    public ObjectiveType objectiveType;
    [SerializeField]
    private string objectiveTargetID;
    [SerializeField]
    public string objectiveDesc;
    [SerializeField]
    public bool objectiveComplete;
    public int objectiveIndex;

    public void Initialise()
    {
        objectiveAmount = defaultObjectiveAmount;
        objectiveComplete = false;
    }
    public bool TryAdvance(string _targetID, ObjectiveType _type)
    {
        if(_type != objectiveType) { return false; }
        if(_targetID == objectiveTargetID)
        {
            objectiveAmount--;
            if (objectiveAmount < 1)
            {
                objectiveComplete = true;
            }
            return true;
        }
        return false;

    }
    public bool isComplete()
    {
        return objectiveComplete;
    }
    
}
