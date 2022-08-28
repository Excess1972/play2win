using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tower_controller : MonoBehaviour
{
	public List<GameObject> enemies_in_range = new List<GameObject>();

	GameObject             _currenttarget;
	private float          _shootingcooldown;
	public  float          _attackspeed = 0.35f;
	public  ParticleSystem shootinganimation;
	public  AudioSource    audiosource;
	public  AudioClip      audioclip;
	public TextMeshProUGUI remainingEnemiesText;

	void FixedUpdate()
	{
		if (_currenttarget)
		{
			if (!_currenttarget.activeSelf)
			{
				InvalidateTarget(_currenttarget);
				return;
			}

			transform.rotation = Quaternion.LookRotation(
				_currenttarget.transform.position - transform.position,
				new Vector3(0, 1, 0)
			);

			if (Time.time > _shootingcooldown)
			{
				shootinganimation.Play();
				audiosource.PlayOneShot(audioclip);
				_shootingcooldown = Time.time + _attackspeed;
				if (_currenttarget.GetComponent<enemy_logic>().Hit(Gamemanager.Instance.gameData.TowerDmg))
				{
					//InvalidateTarget(_currenttarget, true);
					Gamemanager.Instance.addGold(Gamemanager.Instance.gameData.GoldEarned);
				}
			}
		}
		else
		{
			foreach (GameObject enemy in enemies_in_range)
			{
				_currenttarget = enemy;
				_shootingcooldown = Time.time + _attackspeed;
				break;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		enemies_in_range.Add(other.gameObject);
		//switch (AttackPattern)
		//{
		//    case AttackPattern.AF:
		//        break;

		//    case AttackPattern.AL:
		//        break;
		//}

		//AttackFirst();
		//if ()
		//{
		//    AttackFirst();
		//}
		//else if ()
		//{
		//    AttackLast();
		//}
		//else if ()
		//{
		//    AttackStrongest();
		//}   
		//else if ()
		//{
		//    AttackWeakest();
		//}
	}

	private void OnTriggerExit(Collider other)
	{
		InvalidateTarget(other.gameObject);
	}

	public void InvalidateTarget(GameObject validationtarget)
	{
		enemies_in_range.Remove(validationtarget);
		remainingEnemiesText.text = "Remaining Enemies: " + Gamemanager.Instance.enemies.Count.ToString();
		if (_currenttarget == validationtarget)
		{
			_currenttarget = null;
		}
	}

	private void AttackFirst()
	{
		//GameObject distance;
		//foreach (GameObject possibletarget in isTargetable)
		//{
		//    if (isTargetable.Count <= 0)
		//    {
		//        return;
		//    }
		//    distance = Gamemanager.Instance._base.transform.position - possibletarget.transform.position;
		//}
	}

	private void AttackLast()
	{
	}

	private void AttackWeakest()
	{
	}

	private void AttackStrongest()
	{
	}
}

public enum AttackPattern
{
	AF,
	AL,
	AW,
	AS
}