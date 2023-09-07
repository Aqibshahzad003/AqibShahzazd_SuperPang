using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject HeartObject;
    public float maxx, minx;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 4f, 20f);
    }

    public void SpawnObjects()
    {
        if (!GameManager.gameOver)
        {
            //instantiate
            float randPositionX = Random.Range(minx, maxx);
            
                GameObject newHeart = Instantiate(HeartObject, new Vector3(randPositionX, 61.9f, 72f), Quaternion.identity);
                newHeart.transform.eulerAngles = new Vector3(-90, -90, 0);   //changing the rotation when spawned because the original heart rotation is nor correct 

        }
    }
}
