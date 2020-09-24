using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    private static TouchController _instance;
    public static TouchController Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("TouchController is NULL!");
            }
            return _instance;
        }
    }
    public float posX = 0;
    public static event Action OnTap;
    public static event Action<float> OnMove;

    float touchStartTime = 0f;
    [SerializeField]
    float tapTimeMargin = 0.1f;

    private void Awake()
    {
        _instance = this;
    }
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                Vector3 touchPos = hitInfo.point;

                TouchPhase touchPhase = Input.GetTouch(0).phase;
                
                switch(touchPhase)
                {
                    case TouchPhase.Began:
                        posX = touchPos.x;
                        touchStartTime = Time.time;
                        break;
                    case TouchPhase.Moved:
                        posX = touchPos.x;
                        break;
                    case TouchPhase.Stationary:
                        posX = touchPos.x;
                        break;
                    //case TouchPhase.Ended:
                    //    float timePassed = Time.time - touchStartTime;
                    //    Debug.Log(timePassed);
                    //    if(timePassed < tapTimeMargin)
                    //    {
                    //        OnTap?.Invoke();
                    //    }
                    //    break;
                }
            }
        }
        else
        {
            posX = transform.position.x;
        }
    }
}
