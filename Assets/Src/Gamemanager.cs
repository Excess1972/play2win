using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
	public static Gamemanager Instance;

	public  GameData			gameData;
	public  TextMeshProUGUI		goldText;
	public TextMeshProUGUI		remainingEnemiesText;
	public  List<GameObject>	enemies        = new List<GameObject>();
	public  List<GameObject>	active_enemies = new List<GameObject>();
	public  GameObject			enemyPrefab;
	public  GameObject			_base;
	private int					_highscore;
	public  List<Vector3>		towersPositions;

	void Awake()
	{
		Instance = this;
		gameData.BaseHealth = 100;
		gameData.EnemyStartHealth = 125;
		gameData.gold = 300;
		gameData.EnemyDmg = 8;
		gameData.TowerDmg = 25;
		gameData.GoldEarned = 4;
		_highscore = 0;
		initEnemyList(500);
		updateGoldText();
		updateBottonStates();
		towersPositions = new List<Vector3>();
	}

    public void Update()
    {
		remainingEnemiesText.text = "Remaining Enemies: " + Gamemanager.Instance.active_enemies.Count.ToString();
	}

    public int getGold()
	{
		return gameData.gold;
	}

	public void addGold(int amount)
	{
		gameData.gold += amount;
		updateGoldText();
		updateBottonStates();
	}

	public void spendGold(int amount)
	{
		gameData.gold -= amount;

		if (gameData.gold < 0)
		{
			gameData.gold = 0;
		}

		updateGoldText();
		updateBottonStates();
	}

	private void updateGoldText()
	{
		goldText.text = "Gold: " + gameData.gold;
	}

	private void updateBottonStates()
	{
		GameObject.Find("button_tower_1").GetComponent<Button>().interactable = gameData.gold >= 100 ? true : false;
	}

	private void initEnemyList(int size)
	{
		GameObject tmp;
		for (int i = 0; i < size; i++)
		{
			tmp = Instantiate(enemyPrefab);
			tmp.SetActive(false);
			enemies.Add(tmp);
		}
	}

	public void AddHighscore()
	{
		_highscore += 1;
	}

	public int GetHighscore()
	{
		return _highscore;
	}
}