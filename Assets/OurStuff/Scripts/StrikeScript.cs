using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    public float startHeight;
    public float turnAmount;
    public float HorizDistance;
    public bool randomVertSpacing;
    public float Speed;

    public GameObject boltToUse;
    public Vector3 target;

    public List<Vector3> nodes;
    public int currentNode = 0;

    public float interSwapTime;
    public float swapTime;

    // Start is called before the first frame update
    void Start()
    {

        //First Node
        nodes.Insert(0, target + Vector3.up * startHeight);

        float spacing = (startHeight / (turnAmount + 1));

        //Middle Nodes
        for (int i = 1; i <= turnAmount; i++)
        {
            nodes.Add(new Vector3(nodes[0].x + Random.Range(-HorizDistance, HorizDistance), nodes[0].y - 1 * spacing, nodes[0].z + Random.Range(-HorizDistance, HorizDistance)));
        }

        //Last Node
        nodes.Insert(nodes.Count, target);

        Vector3 prevNode = nodes[0];
        float distance = 0;
        foreach (Vector3 _node in nodes)
        {
            distance += Vector3.Distance(prevNode, _node);
            prevNode = _node;
            Debug.Log(distance);
        }

        interSwapTime = (Speed / distance) / turnAmount;
        swapTime = Time.time + interSwapTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > swapTime)
        {
            GetComponent<Rigidbody>().velocity = nodes[currentNode] - transform.position;
            swapTime = Time.time + interSwapTime;
        }
    }
}
