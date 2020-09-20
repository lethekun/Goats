using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public static event Action<int> OnProbDestroyed;

    [SerializeField]
    float enlargeCoeff = 1.1f;
    [SerializeField]
    float exploisonForce = 1500f;
    [SerializeField]
    float exploisoinRadius = 2f;

    public float HitPoint = 100f;
    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Destructable"))
        {
            obj.GetComponent<Rigidbody>().AddExplosionForce(exploisonForce, collision.contacts[0].point, exploisoinRadius, 0.4f, ForceMode.Impulse);
            
            OnProbDestroyed?.Invoke(obj.GetComponent<Destructable>().reward);
            Destroy(obj, 1.5f);            
            Enlarge();
            //Büyüyünce yerin altına giren bir parçası kalmaması için y ekseninde kaldırıyorum.
            transform.position = new Vector3(transform.position.x,transform.position.y * enlargeCoeff, transform.position.z);
            TakeDamage();
        }

    }

    private void Enlarge()
    {
        if (transform.localScale.x < 1f)
            transform.localScale *= enlargeCoeff;
    }

    private void TakeDamage()
    {
        HitPoint -= 20f;
        if(HitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
