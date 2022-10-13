using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public static int score;
    public static int health;

    private void Start()
    {
        score = 0;
        health = 0;
    }

    void Update()
    {
        if (gameObject.CompareTag("ScoreText"))
        {
            text.SetText("SCORE: " + score);
        }

        if (gameObject.CompareTag("HealthText"))
        {
            text.SetText("LIVES: " + health);
        }
    }
}
