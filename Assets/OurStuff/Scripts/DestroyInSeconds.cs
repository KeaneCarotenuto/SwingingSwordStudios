using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public int duration = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(duration);   //Wait
        Destroy(gameObject);
    }
}
