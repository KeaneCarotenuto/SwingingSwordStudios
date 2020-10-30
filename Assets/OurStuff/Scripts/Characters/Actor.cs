using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/*
     This class is attached to every actor in the game. 
     It has datas and functions that relates to them.
 */
public class Actor : MonoBehaviour
{
    /*--- Variables ---*/
    public string myName = "John Cena";
    public Faction faction;
    // Actor Values

    public float health = 100;
    public float healthMax = 100;
    public float mana = 100;
    public float manaMax = 100;
    public float stamina = 100;
    public float staminaMax = 100;
    public float aggression = 4;
    public float attackDamage = 25;
    public float attackSpeed = 1;
    public float attackRange = 30;
    public float moveSpeed = 25;
    public float damageResistance = 10;
    public float spellResistance = 10;
    public float combatRange = 10; // If the distance between this actor and its combat target is less than combatRange, gtfo 
    // User Interface
    public Slider healthbar;
    public GameObject healthBarUI;
    // TEMP, COMBAT SHIT
    public GameObject projectilePrefab;
    public bool bCanAttack = true;

    public GameObject[] linkedObjects;

    public bool isDead = false;
    NavMeshAgent navAgent;
    ActorAnimation myAnim;
    /*--- ---*/
    void Start()
    {
        SetDefaultAV();
        navAgent = GetComponent<NavMeshAgent>();
        myAnim = GetComponent<ActorAnimation>();
    }


    void Update()
    {
        UpdateHealthBar();
        if(health <= 0 && !isDead)
        {
            // dead
            Kill();

            
        }

        if (health <= 0)
        {
            if (GetComponent<QuestTarget>() != null)
            {
                // If this actor is a quest target, trigger the thing
                QuestTarget quest = GetComponent<QuestTarget>();
                quest.Trigger();
            }

            healthbar.GetComponentInParent<Transform>().gameObject.SetActive(false);
        }
        navAgent.speed = moveSpeed;
        
    }

    /*--- Get() Functions ---*/
    public string GetName()
    {
        return name;
    }

    public Faction GetFaction()
    {
        return faction;
    }
    public float GetActorValue(string _sValue)
    {
        switch (_sValue)
        {
            case "health":
                return health;
            case "healthmax":
                return healthMax;
            case "mana":
                return mana;
            case "manaMax":
                return manaMax;
            case "stamina":
                return stamina;
            case "staminaMax":
                return staminaMax;
            case "aggression":
                return aggression;
            case "attackDamage":
                return attackDamage;
            case "attackSpeed":
                return attackSpeed;
            case "moveSpeed":
                return moveSpeed;
            case "damageResistance":
                return damageResistance;
            case "spellResistance":
                return spellResistance;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                return 0;
        }
    }

    public float GetAV(string _sValue)
    {
        // Just a shorthand version of GEtActorValue(). Might delete one of them later.
        switch (_sValue)
        {
            case "health":
                return health;
            case "healthmax":
                return healthMax;
            case "mana":
                return mana;
            case "manamax":
                return manaMax;
            case "stamina":
                return stamina;
            case "staminamax":
                return staminaMax;
            case "aggression":
                return aggression;
            case "attackDamage":
                return attackDamage;
            case "attackSpeed":
                return attackSpeed;
            case "moveSpeed":
                return moveSpeed;
            case "damageResistance":
                return damageResistance;
            case "spellResistance":
                return spellResistance;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                return 0;
        }
    }

    // public MagicEffect[] GetActiveMagicEffects()
    // {
    //     This retrieves all the active magic effects that the actor is currently experiencing.
    //     Will develop more later
    // }

    /*--- Is/has() Functions ---*/
    //public bool IsInFaction(Faction[] _aFactionList){}; Checks if this actor is in one of the factions in a list.
    // public bool IsInCombat() {}; // Check if this person is in combat
    // public bool IsDead() {}; // Check if actor is dead
    // public bool IsDisabled() {};
    // More to be added later.
    /*--- Set() Functions ---*/
    public void SetName(string _sNewName)
    {
        name = _sNewName;
    }

    public void SetActorValue(string _sValueName, float _iNewValue)
    {
        switch (_sValueName)
        {
            case "health":
                health = _iNewValue;
                break;
            case "healthmax":
                healthMax = _iNewValue;
                break;
            case "mana":
                mana = _iNewValue;
                break;
            case "manamax":
                manaMax = _iNewValue;
                break;
            case "stamina":
                stamina = _iNewValue;
                break;
            case "staminamax":
                staminaMax = _iNewValue;
                break;
            case "aggression":
                aggression = _iNewValue;
                break;
            case "attackDamage":
                attackDamage = _iNewValue;
                break;
            case "attackSpeed":
                attackSpeed = _iNewValue;
                break;
            case "moveSpeed":
                moveSpeed = _iNewValue;
                break;
            case "damageResistance":
                damageResistance = _iNewValue;
                break;
            case "spellResistance":
                spellResistance = _iNewValue;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void SetAV(string _sValueName, float _iNewValue)
    {
        // Shorthand version of setactorvalue()
        switch (_sValueName)
        {
            case "health":
                health = _iNewValue;
                break;
            case "healthmax":
                healthMax = _iNewValue;
                break;
            case "mana":
                mana = _iNewValue;
                break;
            case "manamax":
                manaMax = _iNewValue;
                break;
            case "stamina":
                stamina = _iNewValue;
                break;
            case "staminamax":
                staminaMax = _iNewValue;
                break;
            case "aggression":
                aggression = _iNewValue;
                break;
            case "attackDamage":
                attackDamage = _iNewValue;
                break;
            case "attackSpeed":
                attackSpeed = _iNewValue;
                break;
            case "moveSpeed":
                moveSpeed = _iNewValue;
                break;
            case "damageResistance":
                damageResistance = _iNewValue;
                break;
            case "spellResistance":
                spellResistance = _iNewValue;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    void SetDefaultAV()
    {
        //healthMax = 100;
        //health = healthMax;
        manaMax = 100;
        mana = manaMax;
        staminaMax = 100;
        stamina = staminaMax;
        attackSpeed = 2f;
        moveSpeed = 5f;
    }

    /*--- Actions ---*/
    public void Kill() 
    {
        if(GetComponent<QuestTarget>() != null)
        {
            // If this actor is a quest target, trigger the thing
            QuestTarget quest = GetComponent<QuestTarget>();
            quest.Trigger();
        }
        //Destroy(gameObject);
        navAgent.angularSpeed = 0;
        navAgent.isStopped = true;
        health = 0;
        isDead = true;
        myAnim.PlayDeath();
    }
    public void Disable() { }

    public void StartCombat()
    {
        // Pick a fight with the player
        if(GetComponent<ActorBehaviour>() != null)
        {
            ActorBehaviour ai = GetComponent<ActorBehaviour>();
            ai.StartCombatState();
        }
    }
    public void Attack()
    {
        // Fire a projectile in front of this actor. TEMPORARY, WILL CHANGE LATER
        if (bCanAttack)
        {
            // Spawn projectile if ranged enemy. TEMPORARY
            if (attackRange > 5)
            {
                Vector3 spawnPoint = transform.position;
                spawnPoint.y += 2.5f;
                GameObject projectile = Instantiate(projectilePrefab, spawnPoint, transform.rotation, GameObject.Find("BoltContainer").transform);
                projectile.transform.LookAt(GetComponent<ActorBehaviour>().target.transform.position);
                projectile.transform.Rotate(90, 0, 0);
                projectile.GetComponent<Rigidbody>().AddForce((GetComponent<ActorBehaviour>().target.transform.position - new Vector3(0,1.75f,0) - transform.position).normalized * 5000);
            }
            myAnim.PlayAttackAnim();
            bCanAttack = false;
            StartCoroutine("StartAttackCooldown");
        }
       
    }

    public void DamageActorValue(string _sValue, float _iAmount)
    {
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void DamageAV(string _sValue, float _iAmount)
    {
        // Shorthand version of damageactorvalue(). Will only keep one by the end.
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void RestoreActorValue(string _sValue, float _iAmount)
    {
        // Increase actor value. AKA, healing them. WIP
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    public void RestoreAV(string _sValue, float _iAmount)
    {
        // Shorthand version of RestoreActorValue()
        switch (_sValue)
        {
            case "health":
                health -= CalculateDamage(_iAmount);
                break;
            case "healthmax":
                healthMax -= _iAmount;
                break;
            case "mana":
                mana -= _iAmount;
                break;
            case "manaMax":
                manaMax -= _iAmount;
                break;
            case "stamina":
                stamina -= _iAmount;
                break;
            case "staminaMax":
                staminaMax -= _iAmount;
                break;
            case "aggression":
                aggression -= _iAmount;
                break;
            case "attackdamage":
                attackDamage -= _iAmount;
                break;
            case "attackspeed":
                attackSpeed -= _iAmount;
                break;
            case "movespeed":
                moveSpeed -= _iAmount;
                break;
            case "damageresistance":
                damageResistance -= _iAmount;
                break;
            case "spellresistance":
                spellResistance -= _iAmount;
                break;
            default:
                // Entered invalid parameter, return 0
                Debug.Log("DEBUG: You entered a wrong actor value");
                break;
        }
    }

    // public void ApplyMagicEffect(MagicEffect _aMagicEffect) { }

    public void TakeDamage(float _iDamage)
    {
        DamageAV("health", _iDamage);
        StartCombat();
        myAnim.PlayGetHit();
    }

    /*--- Calculate Functions ---*/


    float CalculateDamage(float _iDamage)
    {
        // Calculate the final damage to be taken, taking account the actor's damage and spell resistance
        // WIP
        float iNewValue = _iDamage - damageResistance;
        if (iNewValue < 0)
        {
            iNewValue = 0;
        }
        return iNewValue;
    }
    /*--- UI Functions ---*/
    float CalculateHealthBar()
    {
        // This is to use with the floating healthbar, so it displays the correct amount.
        return health / healthMax;
    }

    void UpdateHealthBar()
    {
        healthbar.value = CalculateHealthBar();

        if (health < healthMax)
        {
            healthBarUI.SetActive(true);
        }
        else if (health > healthMax)
        {
            health = healthMax;
        }
    }

    IEnumerator StartAttackCooldown()
    {
        yield return new WaitForSeconds(attackSpeed);   //Wait
        bCanAttack = true;
    }
}
