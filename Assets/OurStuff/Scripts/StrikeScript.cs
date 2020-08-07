using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    public float startHeight;
    public float turnAmount;
    public float HorizDistance;
    public bool randomVertSpacing;
    [Range(0, 5)] public float Speed;

    public Vector3 target;

    public List<Vector3> nodes;
    private int currentNode = 0;

    private float interSwapTime;
    private float startTime;

    // Start is called before the first frame update
    void Awake()
    {
        //Time.timeScale = 0.5f;
        
        //First Node
        nodes.Insert(0, target + Vector3.up * startHeight);

        transform.position = nodes[0];

        float spacing = (startHeight / (turnAmount + 1));

        //Middle Nodes
        for (int i = 0; i < turnAmount; i++)
        {
            nodes.Add(new Vector3(nodes[0].x + Random.Range(-HorizDistance, HorizDistance), nodes[0].y - i * spacing, nodes[0].z + Random.Range(-HorizDistance, HorizDistance)));
        }

        //Last Node
        nodes.Insert(nodes.Count, target);

        Vector3 prevNode = nodes[0];
        float distance = 0;
        foreach (Vector3 _node in nodes)
        {
            distance += Vector3.Distance(prevNode, _node);
            prevNode = _node;
        }

        startTime = Time.time + 0.5f;
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 _node in nodes)
        {
            Gizmos.DrawWireSphere(_node, 0.5f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= startTime)
        {
            transform.position = Vector3.Lerp(transform.position, nodes[currentNode], Speed);

            if (Vector3.Distance(transform.position, nodes[currentNode]) < 2f && currentNode < nodes.Count-1)
            {
                currentNode++;
            }
        }
    }
}
