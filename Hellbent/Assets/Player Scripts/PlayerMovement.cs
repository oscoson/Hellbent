using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerSpeed = 2.5f;
    public Animator animator;
    public Rigidbody2D playerRB;
    private bool moving;
    private float boostTimer;
    private bool boosting;
    public GameObject dashEffect;
    private static GameObject Instance;
    public AudioSource dashSound;

    // Update is called once per frame
    Vector2 movement;
    private float coolDown;

    void start()
    {
        boosting = false;
        boostTimer = 0f;
        coolDown = 0f;
    }
    void Update()
    {
        //Input in update
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown("space") && coolDown <= 0)
        {
            dashSound.Play();
            boosting = true;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("runStateX", movement.x);
        animator.SetFloat("runStateY", movement.y);

        if (boosting)
        {              
            boostTimer+= Time.deltaTime;
            playerSpeed = 6f;
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            if (boostTimer >= 3)
            {            
                playerSpeed = 2.5f;
                boostTimer = 0;
                boosting = false;
                gameObject.GetComponent<TrailRenderer>().enabled = false;
                coolDown = 5f;
            }
        }
    }

    void FixedUpdate()
    {
        //Movement handeled here
        playerRB.MovePosition(playerRB.position + movement * playerSpeed * Time.fixedDeltaTime);
    }



    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }

    public float GetTimer()
    {
        return(coolDown);
    }
}
