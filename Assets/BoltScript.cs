using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    private float branchTime;
    private float timeBetweenBranch = 0.25f;
    private int itterationNum = 0;
    private int branchAmount = 0;
    private float spawnTime;

    public int maxBranches = 2;
    public int maxItterations = 2;

    public GameObject boltToSpawn;
    public GameObject boltContainer;

    private void Awake()
    {
        spawnTime = Time.time;
        branchTime = Time.time + timeBetweenBranch;
    }

    private void Start()
    {
        if (gameObject.name == "OriginalBolt")
        {
            Debug.Log("FIRST");
            branchTime = Time.time + timeBetweenBranch / 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        spawnTime = Time.time - 9.5f;
    }

    void Update()
    {

        if (Time.time - spawnTime > 10)
        {
            Destroy(gameObject);
        }

        if (GetComponent<Rigidbody>().velocity.magnitude >= 1000)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));

            if (Time.time >= branchTime && itterationNum < maxItterations && branchAmount < maxBranches)
            {
                branchTime = Time.time + timeBetweenBranch;

                branchAmount += 1;

                Debug.Log("Spawn");

                GameObject tempBolt = Instantiate(boltToSpawn, transform.position, transform.rotation, GameObject.Find("BoltContainer").transform);
                tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 6000);
                tempBolt.GetComponent<BoltScript>().itterationNum = itterationNum + 1;
                tempBolt.name = tempBolt.GetComponent<BoltScript>().itterationNum + "Bolt" + branchAmount;
            }
        }
        

        
    }

    public void SetBranch(int _branch)
    {
        itterationNum = _branch;
    }
}

