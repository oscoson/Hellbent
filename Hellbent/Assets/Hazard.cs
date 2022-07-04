using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public PlayerHealth player;
    
    
    public void OnTriggerStay2D(Collider2D collision) 
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "mc")
        {
            player.takeDamage(1);
        }
    }
}
