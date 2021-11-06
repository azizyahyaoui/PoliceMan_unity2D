using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

   
    string levelToLoad;

    [SerializeField]
    GameObject SetttingsWindow;
    public void StartGameButton()
    {
        levelToLoad = "Level01";
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        SetttingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        SetttingsWindow.SetActive(false);
    }


    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void LoadeCreditUI()
    {
        SceneManager.LoadScene("Credits");
    }

}
