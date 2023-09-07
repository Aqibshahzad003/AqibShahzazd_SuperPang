using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private Animator animator;

    public float movespeed;

    [Header("WeaphonsSettings")]
    public GameObject weaphon;
    public GameObject spawnpoint;
    public float fireRate = 0.5f; 
    private float nextFireTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager  = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movements
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);  //changing rotation to right
            animator.SetBool("Run", true);  //setting th ebool parameter to true for animation
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);  //chaning rotation to left
            animator.SetBool("Run", true); //setting th ebool parameter to true for animation

        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);  //chaning back to 0 rotation
            animator.SetBool("Run", false); //setting th ebool parameter to true for animation

        }

        Vector3 Pos = transform.position += Vector3.right * horizontalInput * movespeed * Time.deltaTime;

        Pos.x = Mathf.Clamp(Pos.x, -65, 65);  //clamping the value so it will stay in boundaries of display

        transform.position = Pos;


        //weaphon shooting
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > nextFireTime )  //if all of these are correct then do below
        {
            nextFireTime = Time.time + fireRate;    //controlling the fire rate time
            Instantiate(weaphon, spawnpoint.transform.position, Quaternion.identity); //spawning
        }
    }
    public void VictoryAnimation()
    {
        animator.SetBool("Victory", true);   //setting the bool parameter to true
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Asteroid")
        {
            gameManager.DecreaseHeart();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Heart")
        {
            gameManager.IncreaseHeart();

            Destroy(other.gameObject);

        }
    }
}
