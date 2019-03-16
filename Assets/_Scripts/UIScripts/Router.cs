using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Router : MonoBehaviour
{
    [HideInInspector]public string menu = "MainMenu";
    [HideInInspector] public string game = "Game";
    public void ReplayGame()
    {
        SceneManager.LoadScene(game);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void QuitApplication()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
       
    }
}
