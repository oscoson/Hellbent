using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed, yPos;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mc").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
        Vector2 targetPos = player.position;
        Vector2 smoothPos = Vector2.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        transform.position = new Vector3(smoothPos.x, smoothPos.y + yPos, -15f);

        }
        
    }
}
