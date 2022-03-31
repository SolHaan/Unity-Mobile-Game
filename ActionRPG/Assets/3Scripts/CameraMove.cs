using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //°íÁ¤°ª

    void Update()
    {
        transform.position = target.position + offset;
    }
}
