using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private void Start()
    {
        TinySauce.OnGameStarted(SceneManager.GetActiveScene().buildIndex.ToString());
    }
    public void LoadNextScene()
    {
        TinySauce.OnGameFinished(SceneManager.GetActiveScene().buildIndex.ToString(), true, 0);
        Debug.Log("LoadNextScene clicked!");
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%10);
    }

    public void RestartScene()
    {
        TinySauce.OnGameFinished(SceneManager.GetActiveScene().buildIndex.ToString(), true, 0);
        Debug.Log("RestardScene clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
