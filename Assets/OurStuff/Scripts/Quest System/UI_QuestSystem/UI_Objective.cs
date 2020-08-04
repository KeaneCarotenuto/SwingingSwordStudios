using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Objective : MonoBehaviour
{
    public Text objectiveText;
    public Toggle objectiveToggle;

    public string objectiveDesc;
    public bool objectiveComplete;
    // Start is called before the first frame update
    void Start()
    {
        objectiveText = GetComponentInChildren<Text>();
        objectiveToggle = GetComponent<Toggle>();
        objectiveText.text = objectiveDesc;
        objectiveToggle.isOn = objectiveComplete;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
