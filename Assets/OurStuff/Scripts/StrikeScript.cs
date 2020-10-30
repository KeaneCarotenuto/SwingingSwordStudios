////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : StrikeScript.cs
//--------------------------------------------------------//
//  Description : 
//  Manages the way that the strike attack works
//  
//  
//--------------------------------------------------------//
//    Author    : Keane Carotenuto BSE20021               //
//--------------------------------------------------------//
//    E-mail    : KeaneCarotenuto@gmail.com               //
//========================================================//
////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour
{
    //Public vars
    public float damage;

    public float startHeight;
    public int turnAmount;
    public float HorizDistance;
    public bool randomVertSpacing;
    [Range(0, 5)] public float Speed;

    //Target spot
    public Vector3 target;

    public List<Vector3> nodes;
    private int currentNode = 0;

    private float interSwapTime;
    private float startTime;
    private float endTime;

    void Start()
    {
        //Creates some variabels to be used in point calculation
        startHeight *= Random.Range(1.0f, 2f);
        turnAmount = (int)(turnAmount * Random.Range(0.5f, 2f));
        HorizDistance *= Random.Range(0.5f, 1.5f);
        Speed *= Random.Range(0.5f, 2f);

        //Creates top node for lightning to start at
        nodes.Insert(0, target + Vector3.up * startHeight);

        transform.position = nodes[0];

        float spacing = (startHeight / (turnAmount + 1));

        //Middle Nodes for lightning to bounce between
        for (int i = 0; i < turnAmount; i++)
        {
            nodes.Add(new Vector3(nodes[0].x + Random.Range(-HorizDistance, HorizDistance), nodes[0].y - i * spacing, nodes[0].z + Random.Range(-HorizDistance, HorizDistance)));
        }

        //Last Node to end  at
        nodes.Insert(nodes.Count, target);

        //Calculates the rate at which it should move
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

    //Debug to see points
    private void OnDrawGizmos()
    {
        foreach (Vector3 _node in nodes)
        {
            //Gizmos.DrawWireSphere(_node, 0.5f);
        }
    }

    //Actually moving the bolt prefab between points
    void FixedUpdate()
    {
        //If time to move, then  move
        if (Time.time >= startTime && currentNode < nodes.Count)
        {
            //Next point if current point is done
            if (Vector3.Distance(transform.position, nodes[currentNode]) < 2f && currentNode < nodes.Count-1)
            {
                currentNode++;
            }

            //Lerp between points
            transform.position = Vector3.Lerp(transform.position, nodes[currentNode], Speed);
        }
        
        //If reached the end
        if (currentNode == nodes.Count - 1)
        {
            transform.position = Vector3.Lerp(transform.position, target, Speed);
            currentNode++;
            endTime = Time.time + 5;

            //Deal damage
            ExplosionDamage(transform.position, 10);
        }

        //Del after some time
        if (Time.time >= endTime)
        {
            Destroy(gameObject);
        }
    }

    //Deals damage in area
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
