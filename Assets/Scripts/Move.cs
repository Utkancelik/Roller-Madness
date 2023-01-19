using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody rigidbody;
    private Vector3 movement;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        movement = new Vector3(x, 0f, z);
        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

}
