using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("MusicManager Yok?");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance)
            DestroyImmediate(gameObject);
        else
            _instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
