using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveMultiplier = 1f;
    public Vector3 m_EulerAngleVelocity;
    [SerializeField]
    bool useRigidBody = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (useRigidBody && _rb)
        {
            _rb.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * moveMultiplier);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        else
        {
            transform.Rotate(m_EulerAngleVelocity);
        }
    }
}
