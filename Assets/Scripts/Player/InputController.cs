using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float _horz;
    private float _ver;

    public float Horz { get { return _horz; } }
    public static event Action spacePressed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                _horz = hitInfo.point.x;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            spacePressed?.Invoke();
        }
    }
}
