using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPos;
    public Transform ballContainer;
    private void Awake()
    {
        InputController.spacePressed += SpawnBall;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBall()
    {
        if (ballContainer.childCount == 0)
        {
            GameObject ball = Instantiate(ballPrefab, spawnPos.position, Quaternion.identity);
            ball.transform.parent = ballContainer;
        }
    }
}
