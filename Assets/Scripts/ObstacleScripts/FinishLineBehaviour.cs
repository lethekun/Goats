using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinishLineBehaviour : MonoBehaviour
{
    SpriteRenderer _sr;
    [SerializeField]
    Transform Player;
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.DOFade(0f, 0.1f);
    }

    private void Update()
    {
        if(transform.position.z - Player.position.z <= 15f && transform.position.z - Player.position.z > 2f)
        {
            _sr.DOFade(1f, 1f);
        }
        else if(transform.position.z - Player.position.z <= 2f)
        {
            _sr.DOFade(0f, 0.25f);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Girdi");
    //        _sr.enabled = false;
    //    }
    //}
}
