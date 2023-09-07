using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hearttext;
    private int heart;

    public GameObject stopwatch;

    public GameObject gamewinPanel;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //setting the value of liffe
        heart = 3;
        hearttext.text = heart.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(heart == 0 )   //if life is down to zero then reload the scene 
        {
            gameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
  
    public void IncreaseHeart()  //increasing life
    {
        Debug.Log("Increaselife function called");

        if (heart < 3)
        {
            Debug.Log("Life Increased");
            heart++;
            hearttext.text = heart.ToString();
        }
    }
    public void DecreaseHeart()  //decreasing life
    {
        heart--;
        hearttext.text = heart.ToString();
    }
    public void ActiveGameWinPanel()  //activating gamewin panel is scene 3 (last stage)
    {
        gamewinPanel.gameObject.SetActive(true);
    }
}
