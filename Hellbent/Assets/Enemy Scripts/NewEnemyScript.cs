using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyScript : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float moveSpeed = 5f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {

            if (player.position != null)
            {
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);
                rb.rotation = angle;
                direction.Normalize();
                movement = direction;

            }
        }

    }

    void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


}
