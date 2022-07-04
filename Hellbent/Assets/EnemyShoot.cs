using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private float timeBetweenShots = 0.85f;
    public float shootSpeed;
    private Vector2 moveSpeed;
    public GameObject bullet;
    public Transform shootPosDown;

    public Transform player;


    private bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        GameObject newBulletDown = Instantiate(bullet, shootPosDown.position, Quaternion.identity);
        Rigidbody2D rb = newBulletDown.GetComponent<Rigidbody2D>();
        if(player != null)
        {

            if (player.position != null)
            {
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);
                direction.Normalize();
                rb.AddForce(direction * shootSpeed, ForceMode2D.Impulse);

            }
        }

        canShoot = true;
    }
}
