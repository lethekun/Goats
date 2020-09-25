using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;
using DG.Tweening;

public class Destructable : MonoBehaviour
{
    public enum CubeColor { Red, Green, Blue, Yellow}
    
    [SerializeField]
    public CubeColor cubeColor;

    Animator animator;
    Transform Player;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject puffParticle;
    Vector3 startTransform;
    Rigidbody _rb = null;
    [SerializeField]
    float explosionForce = 1500f;
    [SerializeField]
    float explosionRadius = 2f;
    public int reward = 10;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("ChibiPlayer").transform;

    }
    private void Update()
    {
        MeshRenderer leyla = gameObject.GetComponent<MeshRenderer>();
        float osman = Player.position.z;
        float mahmut = gameObject.transform.position.z;
        float kamil = mahmut - osman;
        if( kamil <= 15f)
        {
            leyla.enabled = true;
           // animator.SetBool("yipyip", true);
          
        }
        else
        {
            leyla.enabled = false;
           
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
