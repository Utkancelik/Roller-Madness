using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject playerDeadEffect;

    private Rigidbody rigidbody;
    private Vector3 movement;
    private TimeManager timeManager;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();
    }
    private void Update()
    {
        if (!timeManager.gameOver && !timeManager.gameFinished)
        {
            MoveThePlayer();
        }

        if (timeManager.gameOver ||timeManager.gameFinished)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        movement = new Vector3(x, 0f, z);
        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        Instantiate(playerDeadEffect, transform.position , Quaternion.identity);
    }
}
