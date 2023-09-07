using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{
    public GameObject asteroids;

    public float maxx, minx;

    public int NumberofObstaclesToSpawn;
    private int SpawnedObs =  0;

    private TransitionLoader transitionLoader;
    private Player player;
    private GameManager gameManager;
    public static bool AllObstalesReleased = false;

    public static bool gamewon = false;
    // Start is called before the first frame update
    void Start()
    {
        AllObstalesReleased = false;
        StartCoroutine(Spawnasteroids());
        transitionLoader = FindAnyObjectByType<TransitionLoader>();
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AllObstalesReleased)  //if all the asterodis are released then this line of codes will perform
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Asteroid");  //finding all the asteroid gameobjects with specific tag

            if(obstacles.Length == 0)  //if there are none then
            {
                StartCoroutine(transitionLoader.LoadLevel()); //load nwxt scene with circle transition
                player.VictoryAnimation();  //player will play animation animation


                //this line of code will only perform only in scene 3(last stage)
                if (SceneManager.GetActiveScene().buildIndex == 2)   //if the stage is last
                {
                    gamewon = true; //setting the bool to true so that the player wont be able to move
                    gameManager.ActiveGameWinPanel();  //setting the gaewin image to true
                }
            }
         
        }

    }

    IEnumerator Spawnasteroids()
    {
        while (SpawnedObs  < NumberofObstaclesToSpawn)   //spawning asteroids till it reaches its amount
        {
            yield return new WaitForSeconds(1);
            //instantiate
            float randPositionX = Random.Range(minx, maxx);  //random position

            Instantiate(asteroids, new Vector3(randPositionX, 61.9f, 72f), Quaternion.identity);

            SpawnedObs++;   //increasing the value of spawned
            
            if(SpawnedObs >= NumberofObstaclesToSpawn)  //if the sapwned amount is reached 
            {
                StopCoroutine(Spawnasteroids());
                AllObstalesReleased = true;
            }

            yield return new WaitForSeconds(3f);
        }
    }
}
