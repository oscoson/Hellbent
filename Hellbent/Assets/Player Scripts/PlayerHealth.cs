using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;
    public float maxHealth = 100;
    public float currentHealth;

    void start()
    {
        currentHealth = maxHealth;
        healthbar.setHealth(maxHealth);
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }

    public void restoreHealth(float hp)
    {
        currentHealth += hp;
        if (currentHealth > maxHealth)
        {
            currentHealth = 100;
        }
        healthbar.setHealth(currentHealth);
    }

    public void DeathState()
    {
        if(this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }

    void OnLoadEnter2D(Collider2D load)
    {
        if (load.gameObject.tag == "Loader")
        {
            // future
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("took damage");
            print(currentHealth);
        }
    }
}
