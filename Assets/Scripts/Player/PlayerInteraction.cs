using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerInteraction : MonoBehaviour
{


    Animator animator;
    [SerializeField]
    GameObject explosionParticle;

    [SerializeField] TMP_Text comboText;


    public static Destructable.CubeColor currentCubeColor;

    [SerializeField]
    AudioSource _audio;

    public static int comboCount = 0;

    public static event Action<int> OnObstacleDestroyed;
    public static event Action OnLevelFinished;
    private void Start()
    {
        animator = GetComponent<Animator>();
        comboText.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Undestructable"))
        {
            AfterDeathSettings();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            AfterFinishSettings();
            OnLevelFinished?.Invoke();
        }

        if (other.gameObject.CompareTag("Destructable"))
        {
            Destructable cube = other.gameObject.GetComponent<Destructable>();

            if (currentCubeColor != cube.cubeColor)
            {
                comboCount = 1;
                //_audio.pitch = 1f;
                _audio.PlayOneShot(cube.clip);
                currentCubeColor = cube.cubeColor;

            }
            else
            {
                comboCount++;
                //_audio.pitch *= 1f;
                _audio.PlayOneShot(cube.clip);
            }

            OnObstacleDestroyed?.Invoke(cube.reward);
        }
    }
    void AfterDeathSettings()
    {
        animator.SetTrigger("isDead");
        GetComponent<PlayerMovement>().enabled = false;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    void AfterFinishSettings()
    {
        animator.SetTrigger("HasFinished");
        GetComponent<PlayerMovement>().enabled = false;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
   
}
