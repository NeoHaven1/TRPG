using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleScroll : MonoBehaviour
{
    //private float RotationSpeed = 5;
    //public int YAngle;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.left * 0.5f, Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.right * 0.5f, Space.World);
        }
    }
}
