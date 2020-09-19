using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Destructable"))
        {
            obj.GetComponent<Rigidbody>().AddExplosionForce(3000f, obj.transform.position, 4f);
            Destroy(obj, 1.5f);
            Destroy(gameObject);
        }
    }
}
