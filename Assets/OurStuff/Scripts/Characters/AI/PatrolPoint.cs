using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public PatrolPoint nextPoint;
    public PatrolPoint prevPoint;

    public int waitTime = 5;

    public PatrolPoint GetNextPoint()
    {
        return nextPoint;
    }

    public void SetNextPoint(PatrolPoint _newPoint)
    {
        nextPoint = _newPoint;
    }

    public PatrolPoint GetPreviousPoint()
    {
        return prevPoint;
    }

    public void SetPreviousPoint(PatrolPoint _newPoint)
    {
        prevPoint = _newPoint;
    }
}
