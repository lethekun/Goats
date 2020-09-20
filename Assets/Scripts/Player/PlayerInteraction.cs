using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            //Destroy(gameObject);
            //
            CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
            cm.enabled = false;
        }
    }
}
