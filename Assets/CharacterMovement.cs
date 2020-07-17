using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool isPossesed = false;
    public GameObject playerCamera;

    public float walkForce = 100;
    public float maxWalkSpeed = 10;
    public float maxSprintSpeed = 30;
    
    [Range(0.0f, 1.0f)] public float drag;

    float maxSpeed;

   void Start()
    {
        drag = 1 - drag;
        maxSpeed = maxWalkSpeed;
    }

    void Update()
    {
        //drag
        GetComponent<Rigidbody>().velocity = new Vector3(drag * GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, drag * GetComponent<Rigidbody>().velocity.z);

        //Sprint Controller
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = maxSprintSpeed;
        }
        else
        {
            maxSpeed = maxWalkSpeed;
        }

        //Forward Movement
        if (Input.GetKey(KeyCode.W))
        {
            //Smooths out movement
            GetComponent<Rigidbody>().AddForce(walkForce * transform.forward * (1 - GetComponent<Rigidbody>().velocity.magnitude / maxSpeed));
        }
        
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    GetComponent<Rigidbody>().velocity += transform.forward * (1 - GetComponent<Rigidbody>().velocity.magnitude/maxSpeed);
        //}

        //Controls Horizontal rotation of Player + Player Cam
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 3;
        transform.localEulerAngles = new Vector3(0f, newRotationX, 0f);
    }
}
