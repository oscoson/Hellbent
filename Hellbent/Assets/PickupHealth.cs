using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject healingEffect;
    public AudioSource pickupHealth;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickupHealth.Play();
            Instantiate(healingEffect, transform.position, Quaternion.identity);
            playerHealth.restoreHealth(10);
            Destroy(this.gameObject);
        }
    }
}
