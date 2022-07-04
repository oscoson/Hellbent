using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHellbent hb;

    public HellbentBar hbBar;
    
    public GameObject deathEffect;

    public GameObject healthPickUp;
    public AudioSource deathSound;
    public AudioSource rockHitSound;
    public PlayerCombat isHellbent;
    public PlayerHealth restore;

 
    void Start()
    {
        currentHealth = maxHealth;
        hbBar.initializeBar();
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
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
               takeDamage(30); 
            }
            else
            {
                takeDamage(15);
            }
        }
    }

    void Die()
    {
        if (isHellbent.activeHellbent)
        {
            restore.restoreHealth(10);
        }
        hb.increaseMeter();
        deathSound.Play();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (Random.Range(0, 100) <= 5)
        {
            if (healthPickUp != null)
            {
                Instantiate(healthPickUp, transform.position, Quaternion.identity);
                Debug.Log("Health Drop");
            }
        }
        Destroy(this.gameObject);
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
