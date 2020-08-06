﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestButton : MonoBehaviour
{
    public Text buttonText;
    public Quest quest;
    public UI_QuestUI questUI;
    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = quest.questName;
        questUI = GetComponentInParent<UI_QuestUI>();
    }

    public void DisplayDetails()
    {
        questUI.DisplayQuestDetails(quest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
