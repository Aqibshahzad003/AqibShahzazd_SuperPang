using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{
    public GameObject spear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(spear);
            Debug.Log("Hit Asteroid");
            //  StartCoroutine(DisableColliders());
            gameObject.tag = "Untagged";  //setting the spear tag to untagged so it wont collide again
        }
    }
}
