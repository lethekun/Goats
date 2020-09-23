using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    GameObject explosionParticle;

    Destructable.CubeColor currentCubeColor;

    [SerializeField]
    AudioSource _audio;

    int comboCount = 0;

    public static event Action<int> OnObstacleDestroyed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Undestructable"))
        {
            AfterDeathSettings();
        }

        if (collision.gameObject.CompareTag("Destructable"))
        {
            Debug.Log("kutu ile etkileşime girildi.");
            Destructable cube = collision.gameObject.GetComponent<Destructable>();
            
            if(currentCubeColor != cube.cubeColor)
            {
                comboCount = 1;
                _audio.pitch = 1f;
                _audio.PlayOneShot(_audio.clip);
                currentCubeColor = cube.cubeColor;
                Debug.Log("Renk farklı. Yeni renk: " + cube.cubeColor.ToString());
            }
            else
            {
                comboCount++;
                _audio.pitch *= 1.1f;
                _audio.PlayOneShot(_audio.clip);
                Debug.Log("COMBO: " + cube.cubeColor.ToString() + " " + comboCount);
            }

            OnObstacleDestroyed?.Invoke(cube.reward*comboCount);
        }
    }

    void AfterDeathSettings()
    {
        animator.SetBool("isDead", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShooter>().enabled = false;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
