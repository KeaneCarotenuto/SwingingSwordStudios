using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The melee attack.
/// </summary>

public class MeleeAttack : MonoBehaviour
{
    public Camera playerCam;
    public Animation swingAnim;
    public float atkDamage;
    public float atkRange;
    public float atkCooldown;
    float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        swingAnim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown > 0) { currentCooldown -= Time.deltaTime; }
        if(Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        currentCooldown += atkCooldown;
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        swingAnim.Play();
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, atkRange))
        {
            if(hit.collider.gameObject.tag == "Interactable")
            {
                hit.collider.gameObject.GetComponent<Actor>().TakeDamage(atkDamage);
            }
        }
    }
}
