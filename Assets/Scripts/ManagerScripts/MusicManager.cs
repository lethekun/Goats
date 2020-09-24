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
        InputController.mousePressed += StartMusic;
    }

    void StartMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.loop = true;
        InputController.mousePressed -= StartMusic;
    }

    private void OnDisable()
    {
        InputController.mousePressed -= StartMusic;
    }
}
