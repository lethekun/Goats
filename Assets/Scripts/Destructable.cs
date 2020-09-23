using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject cubicParticle;
    Vector3 startTransform;
    Rigidbody _rb = null;
    [SerializeField]
    float explosionForce = 1500f;
    [SerializeField]
    float explosionRadius = 2f;
    public static event Action<int> OnObstacleDestroyed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public int reward = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ActivateCubicParticles();
            OnObstacleDestroyed?.Invoke(reward);
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 2f);
            ApplyExplosionForce();
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Melee"))
        {
            ActivateCubicParticles();
            ActivateExplosionParticles();
            OnObstacleDestroyed?.Invoke(reward);
            GetComponentInChildren<ProceduralMeshExploder.MeshExploder>()?.Explode();
            
            //kendini yoket
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

    public void ActivateCubicParticles()
    {
        if (cubicParticle != null)
            Destroy(Instantiate(cubicParticle, transform.position, cubicParticle.transform.rotation), 2f);
        
    }
}
