using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Control Vertical rotaiton seperate from horizontal.
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * 3;
        transform.localEulerAngles = new Vector3(newRotationY, 0f, 0f);
    }
}
