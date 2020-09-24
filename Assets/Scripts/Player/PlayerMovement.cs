using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private InputController _input;
    private TouchController _touch;
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 1f;
    [SerializeField]
    float xPosBoundary = 1f;
    [SerializeField]
    float antiShakeMargin = 0.1f;
    [SerializeField]
    bool isMobile = false;
    bool firstTapDone = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _input = GetComponent<InputController>();
        _touch = GetComponent<TouchController>();
        InputController.mousePressed += WaitForFirstTap;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!firstTapDone) return;

        float horzDif;
        if (isMobile)
        {
            horzDif = TouchController.Instance.posX - transform.position.x;
        }
        else
        {
            horzDif = _input.Horz - transform.position.x;
        }
        
        if (Mathf.Abs(horzDif) > antiShakeMargin)
            horzDif = Mathf.Sign(horzDif);
        else
            horzDif = 0f;

        Vector3 move = new Vector3(horzDif * horizontalSpeed, 0f, forwardSpeed)*Time.smoothDeltaTime;
        
        transform.position += move;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xPosBoundary, +xPosBoundary), transform.position.y, transform.position.z);
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
