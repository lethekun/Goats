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
    bool isMobile = false;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _input = GetComponent<InputController>();
        _touch = GetComponent<TouchController>();

        if (_input == null && _touch != null)
            isMobile = true;
        else if (_input != null && _touch == null)
            isMobile = false;
        else if (_input != null && _touch != null)
            Debug.LogError("İki input controllerı da eklemişsiniz.");
        else
            Debug.LogError("Input girdisi verecek bir component yok!");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horzDif;
        if (isMobile)
        {
            horzDif = TouchController.Instance.posX - transform.position.x;
        }
        else
        {
            horzDif = _input.Horz - transform.position.x;
        }
        
        if (Mathf.Abs(horzDif) > 0.1f)
            horzDif = Mathf.Sign(horzDif);
        else
            horzDif = 0f;

        Vector3 move = new Vector3(horzDif * horizontalSpeed, 0f, forwardSpeed)*Time.smoothDeltaTime;
        
        transform.position += move;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, +3f), transform.position.y, transform.position.z);
    }
}
