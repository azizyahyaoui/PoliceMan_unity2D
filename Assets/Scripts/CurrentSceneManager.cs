using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{

   public bool playerPresentByDefault = false;
   public int numCoinsPickUp;
    public static CurrentSceneManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("CurrentSceneManager");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
