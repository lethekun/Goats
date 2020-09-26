using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    public Destructable.CubeColor newColor;

    [SerializeField]
    Material[] materials;
    Color[] colors;
    GameObject Player;
    SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.DOFade(0f, 0.1f);
        Player = GameObject.Find("ChibiPlayer");
    }
    private void Start()
    {
        PaintColorChanger();
    }

    private void PaintColorChanger()
    {
        colors = new Color[4];
        colors[0] = new Color32(177, 37, 45,255);//red
        colors[1] = new Color32(124, 183, 67, 255);//green
        colors[2] = new Color32(34, 123, 158, 255);//blue
        colors[3] = new Color32(255, 213, 41, 255);//yellow

        Color colorToPaint;
        switch (newColor)
        {
            case Destructable.CubeColor.Red:
                colorToPaint = colors[0];
                break;
            case Destructable.CubeColor.Green:
                colorToPaint = colors[1];
                break;
            case Destructable.CubeColor.Blue:
                colorToPaint = colors[2];
                break;
            case Destructable.CubeColor.Yellow:
                colorToPaint = colors[3];
                break;
            default:
                colorToPaint = colors[3];
                break;
        }
        GetComponent<SpriteRenderer>().color = colorToPaint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInteraction.currentCubeColor = newColor;
            ChangePlayerColor(newColor);
        }
    }

    void Update()
    {
        if (transform.position.z - Player.transform.position.z <= 15f)
        {
            _sr.DOFade(1f, 1f);
        }
    }

    void ChangePlayerColor(Destructable.CubeColor color)
    {
        Material mat;

        switch (color)
        {
            case Destructable.CubeColor.Red:
                mat = materials[0];
                break;
            case Destructable.CubeColor.Green:
                mat = materials[1];
                break;
            case Destructable.CubeColor.Blue:
                mat = materials[2];
                break;
            case Destructable.CubeColor.Yellow:
                mat = materials[3];
                break;
            default:
                mat = materials[3];
                break;
        }

        Player.transform.GetChild(2).GetComponent<SkinnedMeshRenderer>().material = mat;
    }
}
