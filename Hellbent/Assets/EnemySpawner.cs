using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float maxTime = 1;
    private float timer = 0;

    public GameObject enemyimp;

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newenemy = Instantiate(enemyimp);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
