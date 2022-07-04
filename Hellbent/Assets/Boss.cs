using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 500;
    public float currentHealth;
    public HealthBar healthbar;
    public GameObject deathEffect;
    public AudioSource deathSound;
    public AudioSource rockHitSound;
    public PlayerCombat isHellbent;

 
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setHealth(maxHealth);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("Die");
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D rock)
    {
        if (rock.gameObject.tag == "rock")
        {
            rockHitSound.Play();
            if (isHellbent.activeHellbent)
            {
               takeDamage(20); 
            }
            else
            {
                takeDamage(10);
            }
        }
    }

    void Die()
    {

        deathSound.Play();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
       
    }

}
