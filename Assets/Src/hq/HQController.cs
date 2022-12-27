using UnityEngine;
using TMPro;

namespace Src.hq
{
	public class HQController : MonoBehaviour
	{
		public  GameData        gameData;
		private RectTransform   _healthBar;
		public  TextMeshProUGUI highscoreText;
		public  TextMeshProUGUI baseHPText;
		public  GameObject      EndScreen;

		private void OnEnable()
		{
			_healthBar = GetComponentInChildren<RectTransform>();
			_healthBar.sizeDelta = new Vector2(gameData.BaseHealth, 30);
		}

		public void DamageRecieved(int dmg)
		{
			gameData.BaseHealth -= dmg;
			baseHPText.text = "Life Points: " + gameData.BaseHealth.ToString();

			if (gameData.BaseHealth <= 0)
			{
				Die();
			}

			_healthBar.sizeDelta = new Vector2(gameData.BaseHealth, 30);
		}

		private void Die()
		{
			// TODO : animation triggern 
			// TODO : trigger menu screen
			gameObject.SetActive(false);
			highscoreText.text = "Successfully completed waves: " + Gamemanager.Instance.GetHighscore().ToString();
			Time.timeScale = 0;
			EndScreen.SetActive(true);
		}
	}
}