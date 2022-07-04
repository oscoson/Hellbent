using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerMovement movement;

    public PlayerCombat isHellbent;
    public GameObject destroyEffect;
    public AudioSource destroySound;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            ScoreManager.instance.ChangeDestroy(1);
            Die();
        }
    }

    void Die()
    {
        destroySound.Play();
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision) 
    {
      
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "mc")
        {
            movement.playerSpeed = 1.5f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "mc")
        {
            movement.playerSpeed = 2.5f;
        }
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.tag == "rock")
        {
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
}
