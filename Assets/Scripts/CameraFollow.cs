using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    private void FixedUpdate()
    {
        transform.LookAt(target, Vector3.left);
        Vector3 cameraX = target.position;
        cameraX.y = transform.position.y;
        transform.position = cameraX + offSet;

    }

}
