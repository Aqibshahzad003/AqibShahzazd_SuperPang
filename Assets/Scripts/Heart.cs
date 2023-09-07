using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameManager gameManager;
    public float speed;
    public float Rotatespeed;

    private Vector3 originalscale;
    public float scaletime;
    private Vector3 targetscale;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  //accessing the gamemanager script
        originalscale = transform.localScale;  //accessing its original scale at the moment spawn
        targetscale = originalscale * 0.7f;
        StartCoroutine(Scaling());  //starting the scale corutine 
        Destroy(gameObject,9f);  //destroying after 9 sec
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.IncreaseHeart();
            Destroy(gameObject);

            Debug.Log("Increased Life!!");
        }
      
    }

    IEnumerator Scaling()
    {
        float elapsedtime = 0f;   
        while(elapsedtime < scaletime)   //if elapsed time is smaller then scaletime then do the below
        {
            transform.localScale = Vector3.Lerp(originalscale,targetscale,elapsedtime/scaletime);   //changing its scacle 
            elapsedtime += Time.deltaTime;  //increamenting the value of elapsedtime
            yield return null;

        }
        transform.localScale = targetscale;    //giving its new scale
        elapsedtime = 0;  //chaning the elapsedtime back to zero after that
        while (elapsedtime < scaletime)  //again but opposite
        {
            transform.localScale = Vector3.Lerp(targetscale, originalscale, elapsedtime / scaletime);
            elapsedtime += Time.deltaTime;
            yield return null;

        }
        transform.localScale = originalscale;

        StartCoroutine(Scaling());
    }
}
