using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : MonoBehaviour
{
    private Rigidbody rb;
    public float bounceForce = 80f;
    public float minForce = 20f;
    public float maxForce = 40f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Generating a random force  random direction
        Vector3 randomForce = new Vector3(Random.Range(-15f, 15f),Random.Range(-5f, 5f)).normalized * Random.Range(minForce, maxForce);

        // Appling the force to the rigidbody
        rb.AddForce(randomForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spear"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Borders")
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            Debug.Log("Bouncing");
        }
    }


}

