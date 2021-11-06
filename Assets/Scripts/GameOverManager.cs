using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverUI;

    public static GameOverManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("GameOverManager");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
        if(CurrentSceneManager.instance.playerPresentByDefault)
        {
            GameManager.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }
    
    public void ButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HealthPlayer.instance.PlayerReload();
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.numCoinsPickUp);
        gameOverUI.SetActive(false);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonMainMenu()
    {
        GameManager.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Main_Scene");
    }

}
