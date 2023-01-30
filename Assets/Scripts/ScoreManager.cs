using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int score = 0;

    private void Update()
    {
        UpdateScore();

        print(score);
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score : {score}";
    }
}
