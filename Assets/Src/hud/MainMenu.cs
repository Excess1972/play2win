using UnityEngine.SceneManagement;
using UnityEngine;

namespace Src.hud
{
	public class MainMenu : MonoBehaviour
	{
		public void StartGame()
		{
			SceneManager.LoadScene("Playscene");
		}

		public void ExitGame()
		{
			Application.Quit();
		}
	}
}