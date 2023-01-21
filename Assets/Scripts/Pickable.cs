using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.score += scoreAmount;
        Destroy(gameObject);
    }
}
