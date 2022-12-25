using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Src.tower
{
	public class Controller : MonoBehaviour
	{
		public List<GameObject> enemies_in_range = new List<GameObject>();

		GameObject    _currenttarget;
		private float _shootingcooldown;
		public  float _attackspeed = 0.35f;

		// TODO: mit animation vom voxelturm ersetzen
		// public  ParticleSystem shootinganimation;
		public AudioSource audiosource;
		public AudioClip   audioclip;

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
					// shootinganimation.Play();
					gameObject.GetComponentInChildren<Weapon>().MyAttack();
					audiosource.PlayOneShot(audioclip);

					_shootingcooldown = Time.time + _attackspeed;
					if (_currenttarget.GetComponent<enemy.Controller>().Hit(Gamemanager.Instance.gameData.TowerDmg))
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
		}

		private void OnTriggerExit(Collider other)
		{
			InvalidateTarget(other.gameObject);
		}

		public void InvalidateTarget(GameObject validationtarget)
		{
			enemies_in_range.Remove(validationtarget);
			if (_currenttarget == validationtarget)
			{
				_currenttarget = null;
			}
		}
	}
}