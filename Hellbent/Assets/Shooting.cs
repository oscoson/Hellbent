using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    public PlayerMovement player;
    public float bulletForce = 20f;
    public AudioSource rockThrowSound;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
        
    }
    
    void Shoot()
    {
        Vector2 lookDir = mousePos - player.playerRB.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rockThrowSound.Play();
        rb.AddForce(lookDir * bulletForce, ForceMode2D.Impulse);
    }
}
