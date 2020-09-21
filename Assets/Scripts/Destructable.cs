using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject explosionParticle;
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
        if(collision.gameObject.CompareTag("Ball"))
        {
            OnObstacleDestroyed?.Invoke(reward);
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity),2f);
            ApplyExplosionForce();
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Melee"))
        {
            OnObstacleDestroyed?.Invoke(reward);
            GetComponentInChildren<ProceduralMeshExploder.MeshExploder>().Explode();
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 2f);
            //kendini yoket
            Destroy(gameObject);
        }
    }

    public void ApplyExplosionForce()
    {
        _rb.AddExplosionForce(explosionForce, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), explosionRadius, 0.1f);
    }
}
