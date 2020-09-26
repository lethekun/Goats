using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool firstTapDone;

    private void Awake()
    {
        InputController.mousePressed += WaitForFirstTap;
    }
    void Update()
    {
        if (!firstTapDone) return;
        transform.position += new Vector3(0, 0, PlayerMovement.forwardSpeed * Time.smoothDeltaTime);
    }

    void WaitForFirstTap()
    {
        firstTapDone = true;
        InputController.mousePressed -= WaitForFirstTap;
    }

    private void OnDisable()
    {
        InputController.mousePressed -= WaitForFirstTap;
    }

}
