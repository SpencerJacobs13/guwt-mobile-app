﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DistanceWalked : MonoBehaviour
{
    static int distanceWalked = 0;
    Text distanceWalkedText;
    Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        distanceWalked = PlayerPrefs.GetInt("distance", 0);
        distanceWalkedText = GameObject.Find("DistanceWalked").GetComponent<Text>();
        double distanceD = distanceWalked / 5280;
        distanceWalkedText.text = Math.Round(distanceD, 2) + " Miles Walked";

        resetButton = GameObject.Find("ResetButton").GetComponent<Button>();
        resetButton.onClick.AddListener(onResetButtonClicked);
    }

    void onResetButtonClicked()
    {
        PlayerPrefs.SetInt("distance", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
