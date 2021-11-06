using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //-------------------Vars--------------

    private string sceneName;

    [SerializeField]
    GameObject[] objectsGame;

    private Animator FadeSystem;
    public static GameManager instance;

    //-------------------------------------

    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        if (instance != null)
        {
           // Debug.LogWarning("GameManager");
            return;
        }

        instance = this;

       

        //***Dont Destroy On Load objects form previous scene.
        foreach (var element in objectsGame)
        {
            DontDestroyOnLoad(element);
        }
    }

   public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var elements in objectsGame)
        {
            SceneManager.MoveGameObjectToScene(elements, SceneManager.GetActiveScene());
        }
    }



    //---------------loading_a_next_scene------------


    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneName = "Level02";
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(LoadeNextScene());
        }
    }

    public IEnumerator LoadeNextScene()
    {
        FadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
 //-------------------------********---------------------------


   












}