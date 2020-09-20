using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject explosionParticle;
    Vector3 startTransform;
    private void Start()
    {
       
    }
    Vector3 StartTransform()
    {
        return gameObject.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(explosionParticle, StartTransform(), Quaternion.identity);
        }
    }
}
