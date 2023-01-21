using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float levelFinishTime = 15.0f;

    public bool gameFinished = false;
    public bool gameOver = false;
    private void Update()
    {
        if (Time.time >= levelFinishTime && !gameOver)
        {
            gameFinished = true;
        }
    }
}
