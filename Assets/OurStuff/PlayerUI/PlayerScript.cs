using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Player Stats
    public float health = 100;
    public float healthMax = 100;
    public float mana = 100;
    public float manaMax = 100;
    public float stamina = 100;
    public float staminaMax = 100;
    public float healthIncreasePerSecond = 1;
    public float manaIncreasePerSecond = 5;
    public float staminaIncreasePerSecond = 5;

    public ResourceBar healthbar;
    public ResourceBar manabar;
    public ResourceBar staminabar;

    //Shards collectible
    public int shardsCollected = 0;

    //Shards UI
    public GameObject shard1;
    public GameObject shard2;
    public GameObject shard3;
    public GameObject shard1empty;
    public GameObject shard2empty;
    public GameObject shard3empty;

    public GameObject StrikeBar;
    public GameObject DeathText;

    //Seting the variables for the resourcebar slider
    void SetHealth()
    {
        health = healthMax;
        healthbar.SetMaxResource(healthMax);
    }
    void SetMana()
    {
        mana = manaMax;
        manabar.SetMaxResource(manaMax);
    }
    void SetStamina()
    {
        stamina = staminaMax;
        staminabar.SetMaxResource(staminaMax);
    }


    // Start is called before the first frame update
    void Start()
    {
        //Sets resources
        SetHealth();
        SetMana();
        SetStamina();

        //Sets hud
        shard1.gameObject.SetActive(false);
        shard2.gameObject.SetActive(false);
        shard3.gameObject.SetActive(false);
        shard1empty.gameObject.SetActive(true);
        shard2empty.gameObject.SetActive(true);
        shard3empty.gameObject.SetActive(true);

        StrikeBar.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShards();
        //Testing functionality
        //X to reduce health, left click to reduce mana, space to reduce stamina

        HealthRegen();
        ManaRegen();
        StaminaRegen();
 
        if (health <= 0)
        {
            DeathText.SetActive(true);
            health -= 1;
            Time.timeScale = 0;

            if (health < -200)
            {
                SceneManager.LoadScene("MainMenu");
            }

            
        }
    }

    //Function to update resource bar after performing an action
    public void UpdateHealthBar(int cost)
    {
        health -= cost;
        healthbar.SetResource(health);
        if(health < 0)
        {
            health = 0;
        }
    }
 
    public void UpdateManaBar(int cost)
    {
        mana -= cost;
        manabar.SetResource(mana);
        if (mana < 0)
        {
            mana = 0;
        }
    }
    public void UpdateStaminaBar(int cost)
    {
        stamina -= cost;
        staminabar.SetResource(stamina);
        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    //Resource regeneration over time
    void HealthRegen()
    {
        health += healthIncreasePerSecond * Time.deltaTime;

        if (health > 100)
        {
            health = 100;
        }
        healthbar.SetResource(health);
    }

    void ManaRegen()
    {
        mana += manaIncreasePerSecond * Time.deltaTime;

        if (mana > 100)
        {
            mana = 100;
        }
        manabar.SetResource(mana);
    }

    void StaminaRegen()
    {
        stamina += staminaIncreasePerSecond * Time.deltaTime;

        if (stamina > 100)
        {
            stamina = 100;
        }
        staminabar.SetResource(stamina);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collect shard if collided
        if (other.gameObject.CompareTag("Shard"))
        {
            shardsCollected++;
            Destroy(other.gameObject);
        }
    }

    //Update shard hud
    void UpdateShards()
    {
        switch (shardsCollected)
        {
            case 1:
                {
                    shard1.gameObject.SetActive(true);
                    shard2.gameObject.SetActive(false);
                    shard3.gameObject.SetActive(false);
                    shard1empty.gameObject.SetActive(false);
                    shard2empty.gameObject.SetActive(true);
                    shard3empty.gameObject.SetActive(true);
                    StrikeBar.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    shard1.gameObject.SetActive(true);
                    shard2.gameObject.SetActive(true);
                    shard3.gameObject.SetActive(false);
                    shard1empty.gameObject.SetActive(false);
                    shard2empty.gameObject.SetActive(false);
                    shard3empty.gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    shard1.gameObject.SetActive(true);
                    shard2.gameObject.SetActive(true);
                    shard3.gameObject.SetActive(true);
                    shard1empty.gameObject.SetActive(false);
                    shard2empty.gameObject.SetActive(false);
                    shard3empty.gameObject.SetActive(false);
                    break;
                }
            default:
                break;
        }


    }

}
