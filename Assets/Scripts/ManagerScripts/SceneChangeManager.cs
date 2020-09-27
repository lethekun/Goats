using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void LoadNextScene()
    {
        Debug.Log("LoadNextScene clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        Debug.Log("RestardScene clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
