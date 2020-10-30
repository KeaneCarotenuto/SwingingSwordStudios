////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : CharachterMovement.cs                   //
//--------------------------------------------------------//
//  Description : 
//  Manages the player movement and how the player jumps
//  
//  
//--------------------------------------------------------//
//    Author    : Keane Carotenuto BSE20021               //
//--------------------------------------------------------//
//    E-mail    : KeaneCarotenuto@gmail.com               //
//========================================================//
////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //The controller
    public CharacterController controller;
    public TextBoxController tbcontroller;

    //Movement Vars
    [Header("Movement")]
    public float speed = 8f;
    public float sprintMultiplier = 2f;
    public float gravity = -19.62f;
    Vector3 velocity;

    //Jumping Vars
    [Header("Jumping")]
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    

    private void Update()
    {
        //Checks if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Gets input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //If player is not in dialogue
        if (!tbcontroller.InDialogue)
        {
            //Move relative to the axis
            Vector3 move = transform.right * x * 0.65f + transform.forward * z * ((z <= 0) ? 0.6f : 1f);

            controller.Move(move * (speed * (Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1)) * Time.deltaTime);

            //Jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
