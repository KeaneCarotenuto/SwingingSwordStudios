////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : PlayerCamera.cs
//--------------------------------------------------------//
//  Description : 
//  Manages how the camera moves
//  
//  
//--------------------------------------------------------//
//    Author    : Keane Carotenuto BSE20021               //
//--------------------------------------------------------//
//    E-mail    : KeaneCarotenuto@gmail.com               //
//========================================================//
////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public TextBoxController tbcontroller;

    public Transform playerBody;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        //Disable cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Change sensitivity depending on if in dialogue
        mouseSensitivity = (tbcontroller.InDialogue ? 10f : 100f);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate camera with mouse
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        
    }
}
