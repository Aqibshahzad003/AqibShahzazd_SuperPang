using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    public static bool StopTime = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StopTime = true;
        }
    }
}
