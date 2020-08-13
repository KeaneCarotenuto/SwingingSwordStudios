using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {

        Vector3 newRotation = new Vector3(transform.rotation.x + 1, transform.rotation.y + 1, transform.rotation.z + 1);
        transform.Rotate(newRotation);
    }
}
