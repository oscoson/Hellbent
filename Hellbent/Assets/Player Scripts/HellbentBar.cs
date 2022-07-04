using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellbentBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    
    // Update is called once per frame
    public void initializeBar()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    public void setMeter(float meter)
    {
        slider.value = meter;
    }
}
