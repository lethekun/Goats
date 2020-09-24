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
    [SerializeField] TMP_Text osman;


    Destructable.CubeColor currentCubeColor;

    [SerializeField]
    AudioSource _audio;

    int comboCount = 0;

    public static event Action<int> OnObstacleDestroyed;
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

        if (collision.gameObject.CompareTag("Destructable"))
        {
            Destructable cube = collision.gameObject.GetComponent<Destructable>();
            
            if(currentCubeColor != cube.cubeColor)
            {
                comboCount = 1;
                _audio.pitch = 1f;
                _audio.PlayOneShot(_audio.clip);
                currentCubeColor = cube.cubeColor;

            }
            else
            {
                comboCount++;
                _audio.pitch *= 1.03f;
                _audio.PlayOneShot(_audio.clip);
                StartCoroutine(BoomBoomScore());
            }

            OnObstacleDestroyed?.Invoke(cube.reward*comboCount);
        }
    }
    IEnumerator BoomBoomScore()
    {
        // comboText.transform.localScale *= 1.01f;
        comboText.enabled = true;
        comboText.text = "Combo x" + comboCount;
        Animator animCombo = comboText.GetComponent<Animator>();
        animCombo.SetTrigger("boom");
        yield return new WaitForSeconds(.02f);



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
