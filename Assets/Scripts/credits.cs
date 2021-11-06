using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
