﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour
{
    private CountdownTimer countdownTimer;
    private Text textUI;
    private int fadeDuration = 3;
    private bool fading = false;

    void Start()
    {
        textUI = GetComponent<Text>();
        countdownTimer = GetComponent<CountdownTimer>();
        StartFading(fadeDuration);
    }

    void Update()
    {
        if (fading)
        {
            float alphaRemaining = countdownTimer.GetProportionTimeRemaining();
            // print(alphaRemaining);
            Color c = textUI.material.color;
            c.a = alphaRemaining;
            textUI.material.color = c;

            // stop fading when very small number
            if (alphaRemaining < 0.01f)
            {
                fading = false;
                c.a = 0f;
                textUI.material.color = c;
            }
        }
    }

    private void StartFading(int timerTotal)
    {
        countdownTimer.ResetTimer(timerTotal);
        fading = true;
    }
}
