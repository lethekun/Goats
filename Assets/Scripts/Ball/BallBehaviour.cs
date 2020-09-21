using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    [SerializeField]
    float enlargeCoeff = 1.1f;

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
