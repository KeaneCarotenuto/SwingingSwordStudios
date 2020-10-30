using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCompass : MonoBehaviour
{
    public Transform player;
    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Move map depending on player
        vector.z = player.eulerAngles.y;
        transform.localEulerAngles = vector;
    }
}
