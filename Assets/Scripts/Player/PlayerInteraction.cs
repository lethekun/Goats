using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject explosionParticle;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            //particle üret ve yoket
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 2f);
            collision.gameObject.GetComponentInChildren<ProceduralMeshExploder.MeshExploder>().Explode();
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1500, collision.contacts[0].point, 2f);
            Destroy(collision.gameObject);
        }
        //else 
        if (collision.gameObject.CompareTag("Undestructable"))
        {
            AfterDeathSettings();
        }
    }

    void AfterDeathSettings()
    {
        animator.SetBool("isDead", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShooter>().enabled = false;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
