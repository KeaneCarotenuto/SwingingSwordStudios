using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject PCamera;
    public GameObject Bolt;
    public float boltAmount;

    private float nextActionTime;
    private float period = 0.5f;

    private void Start()
    {
        nextActionTime = Time.time + period;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextActionTime)
        {
            nextActionTime = Time.time + period;

            GameObject tempBolt = Instantiate(Bolt, (PCamera.transform.position), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
            tempBolt.GetComponent<Rigidbody>().AddForce(PCamera.transform.forward * 18000);
            tempBolt.name = "OriginalBolt";

        }
    }
}
