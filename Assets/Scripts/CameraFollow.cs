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
        offsetVector = CalculateOffset(target);
    }

    #region Update Methods
    // lateupdate tüm update fonksiyonlarýndan sonra çaðrýlýr
    // fixed update ise fizik hesaplamalarý yapýldýktan sonra çaðrýlýr
    // sýralama : update > (fizik hesaplamalarý yapýldýktan sonra) fixedUpdate > lateUpdate
    // karakteri addForce kullanarak yani fiziksek olarak hareket ettirdigimiz icin fixedUpdate
    #endregion
    private void FixedUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        Vector3 targetToMove = offsetVector + target.position;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.fixedDeltaTime);
        transform.LookAt(target.transform.position);
    }

    private Vector3 CalculateOffset(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }
}
