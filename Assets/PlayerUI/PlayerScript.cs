using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float health = 100;
    public float healthMax = 100;
    public float mana = 100;
    public float manaMax = 100;
    public float stamina = 100;
    public float staminaMax = 100;

    public ResourceBar healthbar;
    public ResourceBar manabar;
    public ResourceBar staminabar;

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
        SetHealth();
        SetMana();
        SetStamina();
    }

    // Update is called once per frame
    void Update()
    {
        //Testing functionality
        //X to reduce health, left click to reduce mana, space to reduce stamina
        if(Input.GetKeyDown(KeyCode.X))
        {
            UpdateHealthBar(20);
        }

       if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UpdateManaBar(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateStaminaBar(20);
        }
    }

    //Function to update resource bar after performing an action
    void UpdateHealthBar(int cost)
    {
        health -= cost;
        healthbar.SetResource(health);
    }
    void UpdateManaBar(int cost)
    {
        mana -= cost;
        manabar.SetResource(mana);
    }
    void UpdateStaminaBar(int cost)
    {
        stamina -= cost;
        staminabar.SetResource(stamina);
    }

}
