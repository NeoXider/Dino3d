using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    void LateUpdate()
    {
        var pos = transform.position;
        pos.x = target.position.x;
        transform.position = pos + offset;
    }
}