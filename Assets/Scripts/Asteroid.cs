using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject smallAsteroidPrefab; // Reference to the smaller asteroid prefab
    public int splitCount = 2; // Number of smaller asteroids to spawn upon destruction
    private bool canSplit = true;

    private Rigidbody rb;
    public float bounceForce = 100f;
    public float horizontalSpeed = 5f;
    private bool movingRight = true;
    //public ParticleSystem destroyparticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (canSplit)
        {
            if (collision.gameObject.CompareTag("Spear"))
            {
                //collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;

                // Spawn smaller asteroids
                for (int i = 0; i < splitCount; i++)
                {
                    Instantiate(smallAsteroidPrefab, transform.position, Quaternion.identity);

                }

                canSplit = false; // Seting the flag to prevent further splitting

                //destroyparticle.Play();
                // Destroy the current asteroid
                gameObject.SetActive(false);
                Destroy(gameObject,2f);
            }
        }
        if (collision.gameObject.tag == "Borders")
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            Debug.Log("Bouncing");
        }
    }

   
}
