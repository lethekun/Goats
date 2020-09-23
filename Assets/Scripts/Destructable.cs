using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class Destructable : MonoBehaviour
{
    public enum CubeColor { Red, Green, Blue, Yellow}
    
    [SerializeField]
    public CubeColor cubeColor;
    
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject puffParticle;
    Vector3 startTransform;
    Rigidbody _rb = null;
    [SerializeField]
    float explosionForce = 1500f;
    [SerializeField]
    float explosionRadius = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public int reward = 10;

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
        if (other.gameObject.CompareTag("Melee"))
        {
            //ActivatePuffParticles();
            //ActivateExplosionParticles();
            //GetComponentInChildren<ProceduralMeshExploder.MeshExploder>()?.Explode();
            //Destroy(gameObject);
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
}
