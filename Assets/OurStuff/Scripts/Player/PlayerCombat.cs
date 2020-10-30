using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public GameObject PCamera;
    public GameObject Bolt;
    public GameObject Strike;
    public GameObject StrikeBar;
    public float boltAmount;

    private float nextActionTime;
    private float period = 0.5f;

    private bool holding = false;
    private float holdingTime;

    private float strikeMaxDamage = 100;
    private float strikeMaxHoldTime = 4;

    public PlayerScript GetPlayerScript;
    public int boltManaCost = 5;
    public int strikeManaCost = 20;

    private void Start()
    {
        nextActionTime = Time.time + period;
        GetPlayerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextActionTime && GetPlayerScript.mana > boltManaCost)
        {
            nextActionTime = Time.time + period;

            GameObject tempBolt = Instantiate(Bolt, (PCamera.transform.position) - new Vector3(0,0.5f,0), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
            tempBolt.GetComponent<BoltScript>().SetSummoner(gameObject); 
            tempBolt.GetComponent<Rigidbody>().velocity = GetComponent<CharacterController>().velocity;
            tempBolt.GetComponent<Rigidbody>().AddForce(PCamera.transform.forward * 30000);
            tempBolt.name = "OriginalBolt";

            GetPlayerScript.UpdateManaBar(boltManaCost);
        }

        if (holding)
        {
            StrikeBar.GetComponent<Slider>().value = Mathf.Clamp((Time.time - holdingTime) * (strikeMaxDamage/strikeMaxHoldTime), 0, strikeMaxDamage) / strikeMaxDamage;
        }
        else
        {
            StrikeBar.GetComponent<Slider>().value = 0;
        }

        if (Input.GetMouseButton(1) && !holding && Time.time >= nextActionTime && GetPlayerScript.mana > strikeManaCost && GetPlayerScript.shardsCollected >= 1)
        {
            holding = true;
            nextActionTime = Time.time + period;
            holdingTime = Time.time;
            //GameObject tempBolt = Instantiate(Strike, (PCamera.transform.position) - new Vector3(0, 0.5f, 0), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
        }

        if (!Input.GetMouseButton(1) && holding && GetPlayerScript.mana > strikeManaCost && GetPlayerScript.shardsCollected >= 1)
        {
            holding = false;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(PCamera.transform.position, PCamera.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject tempStrike = Instantiate(Strike, hit.point, Quaternion.identity, GameObject.Find("BoltContainer").transform);
                tempStrike.GetComponent<StrikeScript>().target = hit.point;
                float tempDmg = Mathf.Clamp((Time.time - holdingTime) * (strikeMaxDamage / strikeMaxHoldTime), 0, strikeMaxDamage);
                tempStrike.GetComponent<StrikeScript>().damage = tempDmg;
                Debug.Log(tempDmg);
                GetPlayerScript.UpdateManaBar(strikeManaCost);
            }
        }
    }
}
