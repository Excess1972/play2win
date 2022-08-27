using UnityEngine;
using TMPro;

public class base_controller : MonoBehaviour
{
	public  GameData		gameData;
	private RectTransform	_healthBar;
	public TextMeshProUGUI	highscoreText;
	public GameObject		EndScreen;

	private void OnEnable()
	{
		gameData.BaseHealth = 100;
		gameData.gold = 10000;
		_healthBar = GetComponentInChildren<RectTransform>();
		_healthBar.sizeDelta = new Vector2(gameData.BaseHealth, 30);
	}

	public void DamageRecieved(int dmg)
	{
		gameData.BaseHealth -= dmg;

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
		highscoreText.text = Gamemanager.Instance.GetHighscore().ToString();
		EndScreen.SetActive(true);
	}
}