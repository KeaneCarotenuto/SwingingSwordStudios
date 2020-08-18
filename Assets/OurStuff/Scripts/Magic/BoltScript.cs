using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    public float boltDamage = 5f;
    public float boltKnockback = 5f;
    
    //Used to control how the lightning splits off and branches.
    private float branchTime;
    private float timeBetweenBranch = 0.1f;     //how long to wait before splitting off
    private int itterationNum = 0;              //Keeps track of which itteration the current bolt is
    private int branchAmount = 0;               //Keeps track of how many bolts this bolt has spawned
    private float spawnTime;
    private float destroyTime = float.MaxValue;

    public int maxBranches;                     //Max number of branches to spawn
    public int maxItterations;                  //Max number of itterations after this one
    public float maxBoltAliveTime;              //Max time after spawning before bolt is destroyed
    public float afterHitAliveTime;             //How long after hitting something should the bolt stay alive
    public float seekDistance;                  //How far away should the bolt Seek out an enemy
    public float seekForce;                     //How much force should be applied when seeking enemy (turn force)
    //public float maxSeekSpeed;                  //How Fast the bolt should snap to target (stors turn force from adding speed)

    public GameObject boltToSpawn;
    public List<GameObject> toSeek;
    public List<GameObject> seeking;

    public GameObject summoner;
    public GameObject boltContainer;

    private void Awake()
    {
        foreach (GameObject _obj in toSeek)
        {
            foreach (GameObject gameObj in FindObjectsOfType(_obj.GetType()))
            {
                if (gameObj.name.Contains("Bandit"))
                {
                    seeking.Add(gameObj);
                }
            }
        }



        //Saves time when spawned, and how long till it can spawn another bolt
        spawnTime = Time.time;
        branchTime = Time.time + timeBetweenBranch;
    }

    private void Start()
    {
        //If the bolt is the origonal, change initial time to split to very soon (makes attack more like shotgun than sniper)
        if (gameObject.name == "OriginalBolt")
        {
            branchTime = Time.time + timeBetweenBranch / 100;
        }
    }

    //When bolt collides with something, make the bolt stick to the object, stop the bolt, 
    private void OnTriggerEnter(Collider other)
    {
        //Dont Hit player
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "En")
        {
            return;
        }
        
        //Stop bolt on contact and set timer to be alive
        transform.parent = other.transform;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        destroyTime = Time.time + afterHitAliveTime;

        //If bolt hits enemy, deal damage and destroy self.
        if (other.name.Contains("Bandit"))
        {
            other.GetComponent<Actor>().TakeDamage(boltDamage);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //If alive for too long, destroy self
        if (Time.time - spawnTime > maxBoltAliveTime || Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }

        //Checks if the bolt is moving
        if (GetComponent<Rigidbody>().velocity.magnitude >= maxBoltAliveTime)
        {
            //If there is anything for the bolt to seek, do this:
            if (seeking.Count > 0)
            {
                //Find cloest object to seek
                float closestDist = 0;
                GameObject closestObj = null;

                foreach (GameObject _obj in seeking)
                {
                    if (_obj == null) continue;

                    if (closestObj == null)
                    {
                        closestObj = _obj;
                        closestDist = Vector3.Distance(transform.position, _obj.transform.position);
                        continue;
                    }

                    if (Vector3.Distance(transform.position, _obj.transform.position) <= closestDist)
                    {
                        closestObj = _obj;
                        closestDist = Vector3.Distance(transform.position, _obj.transform.position);
                    }
                }

                //If closest object is within seeking distance, seek
                if (closestObj != null && closestDist <= seekDistance)
                {
                    //Slow down slightly to counteract current speed
                    GetComponent<Rigidbody>().velocity *= 0.90f;
                    Vector3 seekpos = Vector3.zero;

                    //predict movement
                    if (closestObj.GetComponent<Rigidbody>() != null) {
                        seekpos = 0.1f * closestObj.GetComponent<Rigidbody>().velocity;
                    }
                    //seek
                    GetComponent<Rigidbody>().AddForce(((closestObj.transform.position + Vector3.up + seekpos) - transform.position) * seekForce * (300 / GetComponent<Rigidbody>().velocity.magnitude));
                }
                else
                {
                    //otherwise randomly move
                    GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100)));

                }
            }

            //handles spawning more bolts from this bolt
            if (Time.time >= branchTime && itterationNum < maxItterations && branchAmount < maxBranches)
            {
                branchTime = Time.time + timeBetweenBranch;

                branchAmount += 1;

                //Spawn bolt and give it it's needed characteristics
                GameObject tempBolt = Instantiate(boltToSpawn, transform.position, transform.rotation, GameObject.Find(boltContainer.name).transform);
                tempBolt.GetComponent<BoltScript>().SetSummoner(summoner);
                tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 6000);
                tempBolt.GetComponent<BoltScript>().itterationNum = itterationNum + 1;
                tempBolt.name = tempBolt.GetComponent<BoltScript>().itterationNum + "Bolt" + branchAmount;
            }
        }
    }

    public void SetBranch(int _branch)
    {
        itterationNum = _branch;
    }

    public void SetSummoner(GameObject _summoner)
    {
        summoner = _summoner;
    }

    GameObject GetSummoner()
    {
        return summoner;
    }
}

