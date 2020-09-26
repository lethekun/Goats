using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject endline;
    float firstBeatAsSecond = 2f;
    float firstDrumAsSecond = 18f;
    float secondDrumAsSecond = 42;
    float[] davulSaniyeFarklari = new float[] { 0f, 1f, 1.375f, 1.75f, 3f, 3.375f, 3.75f, 5f, 5.375f, 5.75f, 7f, 7.125f, 7.375f, 7.5f, 7.75f };
    float[] davulSaniyeFarklari2 = new float[] { 0f, 0.375f, 0.75f, 2f, 2.375f, 2.75f };
    void Start()
    {
        float zOffSet = firstBeatAsSecond * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;
        endline.transform.position = new Vector3(0, 2.531f, 45 * PlayerMovement.forwardSpeed);
        //ilk 120 beat kısım
        for (int i = 0; i < (firstDrumAsSecond - firstBeatAsSecond) * 2 - 1; i++)
        {
            if (i % 3 != 0 || i == 0)
            {
                Instantiate(cubes[0], new Vector3(1f, 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
            }
            else
            {
                for (float j = 0f; j < cubes[0].transform.localScale.x * 3; j += cubes[0].transform.localScale.x)
                {
                    Instantiate(cubes[0], new Vector3(j, 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
                }
            }
            //Instantiate(cubes[0], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, zOffSet + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
        }
        //ilk davul kısmı
        float zDrumOffset = firstDrumAsSecond * PlayerMovement.forwardSpeed + cubes[1].transform.localScale.x / 2;
        for(int i = 0; i < davulSaniyeFarklari.Length; i++)
        {
            Instantiate(cubes[1], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, zDrumOffset + davulSaniyeFarklari[i] * PlayerMovement.forwardSpeed), Quaternion.identity);
        }

        //ikinci davula kadar tekrar 120 beat atıyorum
        float ilkDavulSonuPos = (firstDrumAsSecond + 8) * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;
        for (int i = 0; i < (secondDrumAsSecond - firstDrumAsSecond - 8) * 2-1; i++)
        {
            Instantiate(cubes[0], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, ilkDavulSonuPos + i * PlayerMovement.forwardSpeed / 2), Quaternion.identity);
        }
        //ikinci davul
        float zDrumOffset2 = secondDrumAsSecond * PlayerMovement.forwardSpeed + cubes[0].transform.localScale.x / 2;
        for (int i = 0; i < davulSaniyeFarklari2.Length; i++)
        {
            Instantiate(cubes[1], new Vector3(Mathf.Sign(Random.Range(-1f, +1f)) * 2 / 3, 2f, zDrumOffset2 + davulSaniyeFarklari2[i] * PlayerMovement.forwardSpeed), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
