﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Keane Test

    public CharacterController controller;
    public TextBoxController tbcontroller;

    [Header("Movement")]
    public float speed = 8f;
    public float sprintMultiplier = 2f;
    public float gravity = -19.62f;
    Vector3 velocity;


    [Header("Jumping")]
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!tbcontroller.InDialogue)
        {
            Vector3 move = transform.right * x * 0.65f + transform.forward * z * ((z <= 0) ? 0.6f : 1f);



            controller.Move(move * (speed * (Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1)) * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}