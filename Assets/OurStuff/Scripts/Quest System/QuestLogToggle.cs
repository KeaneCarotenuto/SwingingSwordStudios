using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogToggle : MonoBehaviour
{
    [SerializeField]
    public GameObject QuestUI;
    public Transform Canvas;
    private GameObject CurrentUI;
    bool menuOpen;
    [SerializeField]
    public KeyCode key;

    private void Start()
    {
        menuOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            if(!menuOpen)
            {
                CurrentUI = Instantiate(QuestUI);
                CurrentUI.transform.SetParent(Canvas.transform, false);
                
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                menuOpen = true;
                Time.timeScale = 0;

            }
            else
            {
                GameObject.Destroy(CurrentUI);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                menuOpen = false;
                Time.timeScale = 1;
            }
        }
    }
    
}
