using UnityEngine;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class pause_menu_controller : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject EndScreen;

    //is called before start() keeps the pause menu off
    private void Awake()
    {
        PauseMenu.SetActive(false);
        EndScreen.SetActive(false);
    }

    //pauses the game and stops every time action
    public void PauseGame()
    {
        PauseMenu.SetActive(true);

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Playscene");
    }

    public void ExitGame()
    {
        if (Application.isEditor)
        {
            //EditorApplication.isPlaying = false;
            SceneManager.LoadScene("MainMenuscene");
        }
        else
        {
            SceneManager.LoadScene("MainMenuscene");
            //Application.Quit();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
