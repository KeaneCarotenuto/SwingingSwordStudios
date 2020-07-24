using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));

        //GameObject tempBolt = Instantiate(gameObject, transform.position, transform.rotation);
        //tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }
}
