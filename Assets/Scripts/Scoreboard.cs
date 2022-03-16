using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    private void Start() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = $"Score : {score}";
    }

    public void IncreaseScore(int increase) {
        score += increase;
        scoreText.text = $"Score : {score}";
    }   
}
