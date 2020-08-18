using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    public float damage;

    public float startHeight;
    public int turnAmount;
    public float HorizDistance;
    public bool randomVertSpacing;
    [Range(0, 5)] public float Speed;

    public Vector3 target;

    public List<Vector3> nodes;
    private int currentNode = 0;

    private float interSwapTime;
    private float startTime;
    private float endTime;

    // Start is called before the first frame update
    void Start()
    {
        startHeight *= Random.Range(1.0f, 2f);
        turnAmount = (int)(turnAmount * Random.Range(0.5f, 2f));
        HorizDistance *= Random.Range(0.5f, 1.5f);
        Speed *= Random.Range(0.5f, 2f);

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

        startTime = Time.time;

        endTime = Time.time + 10;
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 _node in nodes)
        {
            //Gizmos.DrawWireSphere(_node, 0.5f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= startTime && currentNode < nodes.Count)
        {
            

            if (Vector3.Distance(transform.position, nodes[currentNode]) < 2f && currentNode < nodes.Count-1)
            {
                currentNode++;
            }

            transform.position = Vector3.Lerp(transform.position, nodes[currentNode], Speed);
        }
        
        if (currentNode == nodes.Count - 1)
        {
            currentNode++;
            endTime = Time.time + 2;

            ExplosionDamage(transform.position, 10);
        }



        if (Time.time >= endTime)
        {
            Destroy(gameObject);
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.name.Contains("Bandit"))
            {
                hitCollider.GetComponent<Actor>().TakeDamage(damage);
            }
        }
    }
}
