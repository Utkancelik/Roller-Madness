using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float levelFinishTime = 15.0f;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel, losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();

    public bool gameFinished = false;
    public bool gameOver = false;
    private void Start()
    {
        
    }
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

            UpdateObjectsList("Objects");
            UpdateObjectsList("Enemy");

            foreach (GameObject entity in destroyAfterGame)
            {
                Destroy(entity);
            }
        }

        if (gameOver)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);

            UpdateObjectsList("Objects");
            UpdateObjectsList("Enemy");

            foreach (GameObject entity in destroyAfterGame)
            {
                Destroy(entity);
            }
        }
    }

    private void UpdateObjectsList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }

    private void UpdateTimer()
    {
        timeText.text = $"Time: {(int)Time.timeSinceLevelLoad}";
    }
}
