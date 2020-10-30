////////////////////////////////////////////////////////////
//========================================================//
// Bachelor of Software Engineering                       //
// Media Design School                                    //
// Auckland                                               //
// New Zealand                                            //
//--------------------------------------------------------//
// (c) 2020 Media Design School                           //
//========================================================//
//   File Name  : PlayerCombat.cs
//--------------------------------------------------------//
//  Description : 
//  Manages how the player fights, casts spells, and uses mana
//  
//  
//--------------------------------------------------------//
//    Author    : Keane Carotenuto BSE20021               //
//--------------------------------------------------------//
//    E-mail    : KeaneCarotenuto@gmail.com               //
//========================================================//
////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    //Public vars
    public GameObject PCamera;
    public GameObject Bolt;
    public GameObject Strike;
    public GameObject StrikeBar;
    public float boltAmount;

    //Pivate stuff to manage spell casting
    private float nextActionTime;
    private float period = 0.5f;

    private bool holding = false;
    private float holdingTime;

    //Damages
    private float strikeMaxDamage = 100;
    private float strikeMaxHoldTime = 4;

    public PlayerScript GetPlayerScript;
    public int boltManaCost = 5;
    public int strikeManaCost = 20;

    private void Start()
    {
        //Reset time and get script
        nextActionTime = Time.time + period;
        GetPlayerScript = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Left click spawns bolt in world
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

        //Charing for Strike
        if (holding)
        {
            StrikeBar.GetComponent<Slider>().value = Mathf.Clamp((Time.time - holdingTime) * (strikeMaxDamage/strikeMaxHoldTime), 0, strikeMaxDamage) / strikeMaxDamage;
        }
        else
        {
            StrikeBar.GetComponent<Slider>().value = 0;
        }

        //Right click for strike charge
        if (Input.GetMouseButton(1) && !holding && Time.time >= nextActionTime && GetPlayerScript.mana > strikeManaCost && GetPlayerScript.shardsCollected >= 1)
        {
            holding = true;
            nextActionTime = Time.time + period;
            holdingTime = Time.time;
            //GameObject tempBolt = Instantiate(Strike, (PCamera.transform.position) - new Vector3(0, 0.5f, 0), PCamera.transform.rotation, GameObject.Find("BoltContainer").transform);
        }

        //Rick click relsease for strike shoot
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
