using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.name == "mc" || collision.tag == "hazard" || collision.tag == "pickup" || collision.tag == "Coins"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(this.gameObject);

        }
    
    }
}
