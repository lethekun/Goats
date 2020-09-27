using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignerTwo : MonoBehaviour
{
    public GameObject[] cubes = new GameObject[4];
    public AudioClip[] hitSounds;
    public GameObject endline;
    public GameObject colorChangerPrefab;
    float firstBeatAsSecond = 2f;
    float firstDrumAsSecond = 18f;
    float secondDrumAsSecond = 42;
    float[] davulSaniyeFarklari = new float[] { 0f, 1f, 1.375f, 1.75f, 3f, 3.375f, 3.75f, 5f, 5.375f, 5.75f, 7f, 7.125f, 7.375f, 7.5f, 7.75f };
    float[] davulSaniyeFarklari2 = new float[] { 0f, 0.375f, 0.75f, 1f, 2f, 2.375f, 2.75f, 3f };
    float[] xPositions = new float[] {-1f, 0 , 1f};
    void Start()
    {
        float zOffSet = firstBeatAsSecond * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;
        endline.transform.position = new Vector3(0, 1.51f, 47 * PlayerMovement.forwardSpeed);
        //ilk 120 beat kısım
        for (int i = 0; i < (firstDrumAsSecond - firstBeatAsSecond) * 2 - 1; i++)
        {
            if (i % 3 != 0 || i == 0)
            {
                GameObject cube = Instantiate(cubes[0], new Vector3(1f, 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                cube.GetComponent<Destructable>().clip = hitSounds[8];
            }
            else
            {
                int cubeIndex = Random.Range(0, xPositions.Length);
                for (int j = 0; j < xPositions.Length; j++)
                {
                    if (j == cubeIndex)
                    {
                        GameObject cube = Instantiate(cubes[0], new Vector3(xPositions[j], 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                        cube.GetComponent<Destructable>().clip = hitSounds[8];
                    }
                    else
                    {
                        int randomCubeIndex = Random.Range(2, cubes.Length);
                        GameObject cube = Instantiate(cubes[randomCubeIndex], new Vector3(xPositions[j], 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                        cube.GetComponent<Destructable>().clip = hitSounds[8];
                    }
                }
            }
        }

        //colorchanger
        Instantiate(colorChangerPrefab, new Vector3(0, 1.51f, (firstDrumAsSecond - 0.5f) * PlayerMovement.forwardSpeed), colorChangerPrefab.transform.rotation).GetComponent<ColorChanger>().newColor = cubes[1].GetComponent<Destructable>().cubeColor; ;

        //ilk davul kısmı
        float zDrumOffset = firstDrumAsSecond * PlayerMovement.forwardSpeed + cubes[1].transform.localScale.x / 2;
        for (int i = 0; i < davulSaniyeFarklari.Length; i++)
        {
            GameObject cube = Instantiate(cubes[1], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, zDrumOffset + davulSaniyeFarklari[i] * PlayerMovement.forwardSpeed), Quaternion.identity);
            if (i <= 9)
            {
                cube.GetComponent<Destructable>().clip = hitSounds[Random.Range(0, 3)];
            }
            else
            {
                cube.GetComponent<Destructable>().clip = hitSounds[Random.Range(3, 5)];
            }
        }

        //ikinci davula kadar tekrar 120 beat atıyorum
        float ilkDavulSonuPos = (firstDrumAsSecond + 8) * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;

        //colorchanger
        Instantiate(colorChangerPrefab, new Vector3(0, 1.51f, ilkDavulSonuPos + PlayerMovement.forwardSpeed / 2), colorChangerPrefab.transform.rotation).GetComponent<ColorChanger>().newColor = cubes[0].GetComponent<Destructable>().cubeColor;

        for (int i = 3; i < (secondDrumAsSecond - firstDrumAsSecond - 8) * 2 - 1; i++)
        {
            int cubeIndex = Random.Range(0, xPositions.Length);
            for (int j = 0; j < xPositions.Length; j++)
            {
                if (j == cubeIndex)
                {
                    GameObject cube = Instantiate(cubes[0], new Vector3(xPositions[j], 2f, ilkDavulSonuPos + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                    cube.GetComponent<Destructable>().clip = hitSounds[8];
                }
                else
                {
                    GameObject cube = Instantiate(cubes[Random.Range(2, cubes.Length)], new Vector3(xPositions[j], 2f, ilkDavulSonuPos + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                    cube.GetComponent<Destructable>().clip = hitSounds[8];
                }
            }
            //GameObject cube = Instantiate(cubes[0], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, ilkDavulSonuPos + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
            //cube.GetComponent<Destructable>().clip = hitSounds[8];
        }

        //ikinci davul
        float zDrumOffset2 = secondDrumAsSecond * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;

        //colorchanger
        Instantiate(colorChangerPrefab, new Vector3(0, 1.51f, zDrumOffset2 - PlayerMovement.forwardSpeed / 2), colorChangerPrefab.transform.rotation).GetComponent<ColorChanger>().newColor = cubes[1].GetComponent<Destructable>().cubeColor; ;

        for (int i = 0; i < davulSaniyeFarklari2.Length; i++)
        {
            GameObject cube = Instantiate(cubes[1], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, zDrumOffset2 + davulSaniyeFarklari2[i] * PlayerMovement.forwardSpeed), Quaternion.identity);
            cube.GetComponent<Destructable>().clip = hitSounds[Random.Range(5, 8)];
        }
    }
}
