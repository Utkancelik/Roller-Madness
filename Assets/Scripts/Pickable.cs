using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;
    [SerializeField] private GameObject coinExplosionEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
        }

    }

    private void OnDisable()
    {
        Instantiate(coinExplosionEffect, transform.position, Quaternion.identity);
    }
}
