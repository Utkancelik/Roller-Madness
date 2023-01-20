using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraFollowSpeed = 5.0f;


    private Vector3 offsetVector;

    private void Start()
    {
        offsetVector = transform.position - target.position;
    }
    // lateupdate t�m update fonksiyonlar�ndan sonra �a�r�l�r
    // fixed update ise fizik hesaplamalar� yap�ld�ktan sonra �a�r�l�r
    // s�ralama : update > (fizik hesaplamalar� yap�ld�ktan sonra) fixedUpdate > lateUpdate
    // karakteri addForce kullanarak yani fiziksek olarak hareket ettirdigimiz icin fixedUpdate
    private void FixedUpdate()
    {
        Vector3 targetToMove = offsetVector + target.position;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.fixedDeltaTime);
        transform.LookAt(target.transform.position);
    }
}
