using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject PCamera;
    public GameObject Bolt;
    public GameObject Strike;
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

            GameObject tempBolt = Instantiate(Bolt, (PCamera.transform.position) - new Vector3(0,0.5f,0), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
            tempBolt.GetComponent<BoltScript>().SetSummoner(gameObject); 
            tempBolt.GetComponent<Rigidbody>().velocity = GetComponent<CharacterController>().velocity;
            tempBolt.GetComponent<Rigidbody>().AddForce(PCamera.transform.forward * 30000);
            tempBolt.name = "OriginalBolt";

        }

        if (Input.GetMouseButton(1) && Time.time >= nextActionTime)
        {
            nextActionTime = Time.time + period;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(PCamera.transform.position, PCamera.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject tempStrike = Instantiate(Strike, hit.point, Quaternion.identity, GameObject.Find("BoltContainer").transform);
                tempStrike.GetComponent<StrikeScript>().target = hit.point;
            }

            //GameObject tempBolt = Instantiate(Strike, (PCamera.transform.position) - new Vector3(0, 0.5f, 0), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
        }
    }
}
