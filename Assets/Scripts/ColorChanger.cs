using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public enum Colors { Red, Yellow, Green, Blue};
    [SerializeField]
    Colors newColor;

    GameObject Player;

    private void Awake()
    {
        Player = GameObject.Find("ChibiPlayer");
    }
    void Update()
    {
        
    }
}
