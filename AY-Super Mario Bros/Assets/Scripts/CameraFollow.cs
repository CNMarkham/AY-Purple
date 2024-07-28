using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        // camera follow the horizontal movement of the player(target)
        if (target.position.x > transform.position.x)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
