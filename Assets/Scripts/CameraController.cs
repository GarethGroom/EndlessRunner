using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        //Sets the cameras offset to be behind the player
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        //Updates the camera to be behind the player at all times=
        Vector3 newPosition = new Vector3(offset.x + target.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 1f);
    }
}
