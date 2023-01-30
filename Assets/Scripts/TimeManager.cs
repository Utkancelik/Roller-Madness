using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float levelFinishTime = 15.0f;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel, losePanel;
    public bool gameFinished = false;
    public bool gameOver = false;
    private void Update()
    {
        if (!gameFinished && !gameOver)
        {
            UpdateTimer();
        }

        if (Time.timeSinceLevelLoad >= levelFinishTime && !gameOver)
        {
            gameFinished = true;
            winPanel.SetActive(true);
            losePanel.SetActive(false);
        }

        if (gameOver)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }
    }

    private void UpdateTimer()
    {
        timeText.text = $"Time: {(int)Time.timeSinceLevelLoad}";
    }
}
