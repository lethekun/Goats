using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private InputController _input;
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 1f;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horzDif = _input.Horz - transform.position.x;
        if (Mathf.Abs(horzDif) > 0.1f)
            horzDif = Mathf.Sign(horzDif);
        else
            horzDif = 0f;

        Vector3 move = new Vector3(horzDif * horizontalSpeed, 0f, forwardSpeed)*Time.smoothDeltaTime;
        
        transform.position += move;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, +3f), transform.position.y, transform.position.z);
    }
}
