using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int score;

    public int destroyed;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString() + "/6";
    }

    public void ChangeDestroy(int destroyValue)
    {
        destroyed += destroyValue;
        text.text = destroyed.ToString() + "/4";
    }
}
