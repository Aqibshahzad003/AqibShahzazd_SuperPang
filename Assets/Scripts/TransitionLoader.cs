using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{
    public Animator animator;

    public float transitionTime;

    private void Start()
    {
       //StartCoroutine (LoadLevel());
    }
    public IEnumerator LoadLevel()  //corutine which will load next scene with circle transition
    {
        yield return new WaitForSeconds(3f);

        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("New scene");
    }

}
