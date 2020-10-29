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

    /// <summary>
    /// Initialises the Objective.
    /// </summary>
    public void Initialise()
    {
        objectiveAmount = defaultObjectiveAmount;
        objectiveComplete = false;
    }
    /// <summary>
    /// Tries to advance objective.
    /// </summary>
    /// <param name="_targetID">The _target i d.</param>
    /// <param name="_type">The _type.</param>
    /// <returns>A bool.</returns>
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
    /// <summary>
    /// Gets a value indicating whether is complete.
    /// </summary>
    public bool IsComplete => objectiveComplete;

}
