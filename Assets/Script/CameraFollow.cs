using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Start()
{
    Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
}

    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
            );
        }
    }
}
