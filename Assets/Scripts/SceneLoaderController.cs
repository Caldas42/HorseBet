using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderController : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
