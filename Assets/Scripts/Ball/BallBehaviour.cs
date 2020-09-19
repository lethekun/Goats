using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    float enlargeCoeff = 1.1f;
    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Destructable"))
        {
            obj.GetComponent<Rigidbody>().AddExplosionForce(1500f, obj.transform.position, 4f);
            Destroy(obj, 1.5f);
            transform.localScale *= enlargeCoeff;
            transform.position = new Vector3(transform.position.x,transform.position.y * enlargeCoeff, transform.position.z);
        }
    }
}
