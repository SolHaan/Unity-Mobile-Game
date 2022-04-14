using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;

    public float speed;

    public float minX, maxX, minY, maxY;

    void Awake()
    {
        target = FindObjectOfType<PlayerController>().transform;
        //transform.position = target.position;
    }

    void Update()
    {
        if (GameManager.Instance.Round > 3)
        {
            speed = 0;
            maxX = 0;
            gameObject.transform.position = new Vector3(minX, minY, transform.position.z);
        }

        if (target != null)
        {
            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);

            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), new Vector3(clampedX, clampedY, -10), speed);
        }
    }
}
