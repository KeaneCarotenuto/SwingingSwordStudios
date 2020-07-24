using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    private float branchTime;
    private float timeBetweenBranch = 0.5f;
    public int branchItter = 0;
    public int branchAmount = 0;
    private float spawnTime;

    public int maxBranches = 2;
    public int maxBranchRepeats = 2;

    public GameObject boltToSpawn;

    private void Awake()
    {
        spawnTime = Time.time;
        branchTime = Time.time + timeBetweenBranch;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        spawnTime = Time.time - 9.5f;
    }

    void Update()
    {

        if (Time.time - spawnTime > 10)
        {
            Destroy(gameObject);
        }

        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));

        if (Time.time >= branchTime && branchItter < maxBranchRepeats && branchAmount < maxBranches)
        {
            branchTime = Time.time + timeBetweenBranch;

            branchAmount += 1;

            Debug.Log("Spawn");

            GameObject tempBolt = Instantiate(boltToSpawn, transform.position, transform.rotation, transform);
            
            tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            tempBolt.GetComponent<BoltScript>().branchItter = branchItter + 1;
            tempBolt.name = tempBolt.GetComponent<BoltScript>().branchItter + "Bolt" + branchAmount;

        }
    }

    public void SetBranch(int _branch)
    {
        branchItter = _branch;
    }
}

