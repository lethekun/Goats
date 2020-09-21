using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestructable : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructable"))
        {
            FindObjectOfType<PlayerInteraction>().animator.SetTrigger("isDestructable");
        }
    }
}
