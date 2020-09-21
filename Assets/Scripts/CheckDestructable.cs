using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestructable : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructable"))
        {
            transform.parent.gameObject.GetComponent<Animator>().SetTrigger("isDestructable");
        }
    }
}
