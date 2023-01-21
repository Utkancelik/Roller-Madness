using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isCollided = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!isCollided)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            FindObjectOfType<ScoreManager>().score -= 5;

            isCollided = true;
        }   
    }
}
