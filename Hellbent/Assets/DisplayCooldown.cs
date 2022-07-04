using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCooldown : MonoBehaviour
{
    public static DisplayCooldown instance;
    public PlayerMovement boostTime;
    public Text text;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if(boostTime.GetTimer() <= 0)
        {
            text.text = "Space";
        }
        else 
        {
            text.text = Mathf.Round(boostTime.GetTimer()).ToString();
        }
    }
}
