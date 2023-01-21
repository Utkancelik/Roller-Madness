using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f, stopDistance = 3.0f;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(target);



        if (Vector3.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }

    }
}
