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

    [SerializeField]
    private AudioClip[] clips;

    private AudioSource _audioSource;

    enum MusicStates { Intro, Outro}


    void Awake()
    {
        if (_instance)
            DestroyImmediate(gameObject);
        else
            _instance = this;
        InputController.mousePressed += StartMusic;
        _audioSource = GetComponent<AudioSource>();
    }

    void StartMusic()
    {
        _audioSource.clip = clips[0];
        _audioSource.Play();
        _audioSource.loop = false;
        InputController.mousePressed -= StartMusic;

        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        while (_audioSource.isPlaying)
            yield return null;

        _audioSource.PlayOneShot(clips[1],1f);
        _audioSource.clip = clips[2];
        _audioSource.PlayDelayed(1.5f);
        _audioSource.loop = true;
    }

    private void OnDisable()
    {
        InputController.mousePressed -= StartMusic;
    }
}
