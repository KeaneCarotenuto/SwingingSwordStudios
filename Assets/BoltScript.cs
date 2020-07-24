using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    private float nextActionTime;
    private float period = 0.5f;
    public int branchItter = 0;
    public int branchAmount = 0;
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
        nextActionTime = Time.time + period;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime > 10)
        {
            Destroy(gameObject);
        }

        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));

        if (Time.time >= nextActionTime && branchItter < 2 && branchAmount < 2)
        {
            nextActionTime = Time.time + period;

            branchAmount++;

            Debug.Log("Spawn");

            GameObject tempBolt = Instantiate(gameObject, transform.position, transform.rotation, transform);
            tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
            tempBolt.GetComponent<BoltScript>().SetBranch(1 + branchItter);
        }
    }

    public void SetBranch(int _branch)
    {
        branchItter = _branch;
    }
}

