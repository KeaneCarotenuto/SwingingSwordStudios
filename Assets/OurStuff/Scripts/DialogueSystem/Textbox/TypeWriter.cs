using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypeWriter : MonoBehaviour 
{

	Text txt;
    public string story;
    public Textbox Box;
    public GameObject Textbox;
    public float Speed;
    public bool Typing;
    public AudioSource Blip;
    

    void Start()
    {
        Textbox = GameObject.FindGameObjectWithTag("Textbox");
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";
        Box = Textbox.GetComponent<Textbox>();
        Speed = Box.TypeSpeed;
        Typing = true;
        // TODO: add optional delay when to start
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        
        
        foreach (char c in story)
        {
            if (Typing)
            {
                Blip.Play();
                txt.text += c;
            }
            yield return new WaitForSeconds(Speed);
        }
        Typing = false;
        gameObject.GetComponent<TypeWriter>().enabled = false;
    }

}
