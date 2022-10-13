using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    [Header("References")]
    [Tooltip("TMPro text to edit to show the values of both the score and the health.")]
    [SerializeField] private TextMeshProUGUI text;
    
    [Header("Variables")]
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
