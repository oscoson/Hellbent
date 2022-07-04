using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPF : MonoBehaviour
{

    public GameObject dieEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "mc" || collisionGameObject.tag == "rock" || collisionGameObject.tag == "Brick" || collisionGameObject.tag == "Prison")
        {
            GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

    }
}
