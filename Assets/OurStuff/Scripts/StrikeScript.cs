using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    public float startHeight;
    public float turnAmount;
    public float turnHorizDistance;
    public bool randomVertSpacing;
    public float Speed;

    public GameObject boltToUse;
    public GameObject target;

    private List<Vector3> nodes;

    // Start is called before the first frame update
    void Start()
    {
        nodes.Add(target.transform.position + Vector3.up * startHeight);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
