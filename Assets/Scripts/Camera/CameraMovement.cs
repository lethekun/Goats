using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.position += new Vector3(0, 0, moveSpeed * Time.smoothDeltaTime);
    }
}
