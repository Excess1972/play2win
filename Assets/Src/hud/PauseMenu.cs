using UnityEngine;
using UnityEngine.SceneManagement;

namespace Src.hud
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        public GameObject endScreen;

        //is called before start() keeps the pause menu off
        private void Awake()
        {
            pauseMenu.SetActive(false);
            endScreen.SetActive(false);
        }

        //pauses the game and stops every time action
        public void PauseGame()
        {
            pauseMenu.SetActive(true);

            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);

            Time.timeScale = 1;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Playscene");

            Time.timeScale = 1;
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
                if (pauseMenu.activeSelf)
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
}
