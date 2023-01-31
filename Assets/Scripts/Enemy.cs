using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f, stopDistance = 3.0f;
    [SerializeField] private GameObject enemyExplosionEffect;

    private Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            if (Vector3.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position += speed * Time.deltaTime * transform.forward;
            }
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
            Destroy(collision.gameObject);  
        }
    }

    private void OnDisable()
    {
        Instantiate(enemyExplosionEffect,transform.position, Quaternion.identity);
    }
}
