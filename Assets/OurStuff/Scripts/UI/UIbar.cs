using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbar : MonoBehaviour
{
    public GameObject bar;
    public float barMax;
    public float barPercent;
    void Start()
    {
        barMax = bar.GetComponent<RectTransform>().sizeDelta.x;
        barPercent = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2(barPercent * barMax, bar.GetComponent<RectTransform>().sizeDelta.y);
    }
}
