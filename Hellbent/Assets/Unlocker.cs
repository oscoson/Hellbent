using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public ScoreManager score;
    public GameObject door;
    public AudioSource doorUnlockSound;

    public bool enemyOnly;

    void Update()
    {
        if ((score.destroyed == 4 || score.score == 6 || enemyOnly) && (GameObject.FindWithTag("Enemy") == null) && (GameObject.FindWithTag("Boss") == null))
        {
            doorUnlockSound.Play();
            door.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }

    }
}
