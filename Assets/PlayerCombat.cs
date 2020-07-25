﻿using System.Collections;
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
            //for (int i = 0; i < boltAmount; i++)
            //{

            //}

            GameObject tempBolt = Instantiate(Bolt, (PCamera.transform.position), PCamera.transform.rotation);
            tempBolt.GetComponent<Rigidbody>().AddForce(PCamera.transform.forward * 6000);

        }
    }
}