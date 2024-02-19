using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayfabManager m_PlayfabManager;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_PlayfabManager= FindObjectOfType<PlayfabManager>();
    }
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
    public void SubmitToLeaderBoard()
    {
        // Ensure m_PlayfabManager is not null
        if (m_PlayfabManager != null)
        {
                int score = BalloonSpawner.Score;
                m_PlayfabManager.SendToLeaderboard(score);

        }
        else
        {
            Debug.LogWarning("PlayfabManager not found in the scene.");
        }
    }

}
