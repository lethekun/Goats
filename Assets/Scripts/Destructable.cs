using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Destructable : MonoBehaviour
{
    public enum CubeColor { Red, Green, Blue, Yellow}
    
    [SerializeField] public CubeColor cubeColor;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject puffParticle;
    [SerializeField] float explosionForce = 1500f;
    [SerializeField] float explosionRadius = 2f;

    public int reward = 10;
    public AudioClip clip;

    Animator animator;
    Transform Player;
    Vector3 startTransform;
    Rigidbody _rb = null;

    public static event Action OnBoxMissed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("ChibiPlayer").transform;

    }
    private void Update()
    {
        MeshRenderer mRenderer = gameObject.GetComponent<MeshRenderer>();
        float playerZPos = Player.position.z;
        float destructableZPos = gameObject.transform.position.z;
        float zDiff = destructableZPos - playerZPos;
        
        if (zDiff > 15f)
        {
            mRenderer.enabled = false;
        }
        else if ( zDiff <= 15f && zDiff >= -2)
        {
            mRenderer.enabled = true;
           // animator.SetBool("yipyip", true);
          
        }
        else
        {
            //if(_gameMode == GameModes.Hard)
            //{
                //PlayerInteraction.comboCount = 0;
                //OnBoxMissed?.Invoke();
            //}
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivatePuffParticles();
            ActivateExplosionParticles();
            GetComponentInChildren<ProceduralMeshExploder.MeshExploder>()?.Explode();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActivatePuffParticles();
            ActivateExplosionParticles();
            GetComponentInChildren<ProceduralMeshExploder.MeshExploder>()?.Explode();
            Destroy(gameObject);
        }
    }

    public void ApplyExplosionForce()
    {
        _rb.AddExplosionForce(explosionForce, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), explosionRadius, 0.1f);
    }

    void ActivateExplosionParticles()
    {
        if(explosionParticle != null)
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 1f);
    }

    public void ActivatePuffParticles()
    {
        if (puffParticle != null)
            Destroy(Instantiate(puffParticle, transform.position, puffParticle.transform.rotation), 1f);        
    }
    //IEnumerator FadeColor()
    //{
    //    MeshRenderer Osman =  gameObject.GetComponent<MeshRenderer>();        
    //    Osman.material.DOColor(Color.blue, 3f);
    //    yield return new WaitForSeconds(2f);
    //    Osman.material.DOColor(Color.red, 3f);
    //}


}
