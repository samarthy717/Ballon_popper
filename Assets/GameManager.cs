using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowLeadorboard()
    {
        //show the leadorboard
        SceneManager.LoadScene(0);
    }
    public void GameEnd()
    {
        SceneManager.LoadScene(2);
    }
}
