using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    [SerializeField]
    float MaxAngleDeflection = 30.0f;
    [SerializeField]
    float SpeedOfPendulum = 1.0f;

    void Update()
    {
        float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

    }
}
