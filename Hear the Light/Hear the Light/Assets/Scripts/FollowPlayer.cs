using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; 
    public Vector3 cameraOffset; 
    public float smoothSpeed = 10f; 

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); 
        transform.position = smoothedPosition;    

        transform.LookAt(target); 
    }
}
