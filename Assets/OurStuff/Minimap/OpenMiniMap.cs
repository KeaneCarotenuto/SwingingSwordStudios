using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMiniMap : MonoBehaviour
{
    public bool MiniMapOpen = false;
    public GameObject BigMiniMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Opens minimap if not already open
        if (Input.GetKeyDown(KeyCode.M) && MiniMapOpen == false)
        {
            BigMiniMap.SetActive(true);
            MiniMapOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && MiniMapOpen == true)
        {
            BigMiniMap.SetActive(false);
            MiniMapOpen = false;
        }
    }
}
