using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject title;
    public GameObject button;
    public GameObject button2;
    public float delay = 8;
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(false);
        button.SetActive(false);
        button2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SetActive());
    }

    public IEnumerator SetActive()
    {
        yield return new WaitForSeconds(delay);
        title.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);
    }

}
