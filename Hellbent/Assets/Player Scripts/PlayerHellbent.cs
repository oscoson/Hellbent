using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHellbent : MonoBehaviour
{
    // Start is called before the first frame update
    public HellbentBar bar;
    public int maxMeter = 100;
    public float currentMeter;

    public PlayerCombat hellbentStatus;
    void start()
    {
        bar.initializeBar();
    }

    public void increaseMeter()
    {
        if (currentMeter < 100 && !(hellbentStatus.activeHellbent))
        {
            currentMeter += Random.Range(10, 30);
            Debug.Log(currentMeter);
            bar.setMeter(currentMeter);
        }
    }

    public void decreaseMeter()
    {
        currentMeter -= 0.1f;
        bar.setMeter(currentMeter);
    }


    // Update is called once per frame
}
