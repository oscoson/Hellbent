using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask objectives;
    public LayerMask bossLayer;
    
    public int attackDamage = 30;

    public int damageTaken = 5;

    public bool activeHellbent = false;
    public PlayerHealth playerHealth;

    public PlayerHellbent hellbentplayer;

    public GameObject hellbentEffect;
    public AudioSource swingSound;
    public AudioSource hellbentSound;


    void Start()
    {
    }
 
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if (hellbentplayer.currentMeter >= 100 && activeHellbent == false)
        {
            Debug.Log("Hellbent Activated");
            isHellbent();
        }

        if (activeHellbent)
        {
            if (hellbentplayer.currentMeter >= 100)
            {
                hellbentplayer.currentMeter = 100;
            }
            hellbentplayer.decreaseMeter();
            // debuffs
            if (!(playerHealth.currentHealth <= 5))
            {
                playerHealth.takeDamage(0.06f);
            }
            if (hellbentplayer.currentMeter <= 0)
            {
                activeHellbent = false;
                hellbentplayer.currentMeter = 0;
                Debug.Log("Back to Normal");
                noHellbent();
            }
        }
        
    }

    public void setDamageTaken(int damage)
    {
        damageTaken = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerHealth.takeDamage(damageTaken);
        }

        else if (other.gameObject.tag == "Coins") {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ranged gunk")
        {
            playerHealth.takeDamage(5f);
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision) 
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.gameObject.tag == "Boss")
        {
            playerHealth.takeDamage(3f);
        }
    }

    public void isHellbent()
    {
        hellbentSound.Play();
        hellbentplayer.currentMeter = 100;
        activeHellbent = true;
        // buffs
        Debug.Log("Buff Active");
        attackDamage = 60;
        damageTaken = 10;
        Instantiate(hellbentEffect, transform.position, Quaternion.identity);
        
    }

    public void noHellbent()
    {
        // Normal Stats
        attackDamage = 30;
        damageTaken = 5;
    }

    void Attack()
    {
        //Play an attack animation
        //Detect enemies in range of attack
        //Damage enemy
        animator.SetTrigger("Attack");
        swingSound.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitObjectives = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, objectives);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            Enemy currentEnemy = enemy.GetComponent<Enemy>();
            currentEnemy.takeDamage(attackDamage);


            
        }

        foreach(Collider2D obj in hitObjectives)
        {
            Debug.Log("We hit" + obj.name);
            Tower currentObjective = obj.GetComponent<Tower>();
            currentObjective.takeDamage(attackDamage);

            
        }
        foreach(Collider2D boss in hitBoss)
        {
            Debug.Log("We hit" + boss.name);
            Boss currentBoss = boss.GetComponent<Boss>();
            currentBoss.takeDamage(attackDamage / 2);


            
        }
    }

    void onDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
