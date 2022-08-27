using UnityEngine.SceneManagement;
//using UnityEditor;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    public GameObject MainMenu;
  
    public void StartGame()
    {
        SceneManager.LoadScene("Playscene");
    }

    public void ExitGame()
    {
        //if (Application.isEditor)
        //{
        //    EditorApplication.isPlaying = false;
        //}
        //else
        //{
            Application.Quit();
       // }
    }
}
