using UnityEngine;
using UnityEngine.AI;

public class enemy_logic : MonoBehaviour
{
	public  Animator      _animator;
	private NavMeshAgent  _agent;
	private int           _energy;
	private RectTransform _eneryBar;
	private GameData      gameData;

	void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		gameData = Gamemanager.Instance.gameData;
	}

	private void OnEnable()
	{
		_energy = gameData.EnemyStartHealth;
		_eneryBar = GetComponentInChildren<RectTransform>();
		_eneryBar.sizeDelta = new Vector2(100, 30);
		_animator.SetBool("Run Forward", true);
	}

	public bool Hit(int damageValue)
	{
		_energy -= damageValue;

		if (_energy <= 0)
		{
			Die();
			return true;
		}

		_eneryBar.sizeDelta = new Vector2(_energy, 30);
		return false;
	}

	private void Die()
	{
		// TODO : animation triggern 
		gameObject.SetActive(false);
		Gamemanager.Instance.active_enemies.Remove(gameObject);
	}

	// Triggered when enemy reaches base 
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Gamemanager.Instance._base)
		{
			other.gameObject.GetComponent<base_controller>().DamageRecieved(25);
			Die();
		}
	}

	public void SetAgentDestination()
	{
		_agent.SetDestination(Gamemanager.Instance._base.transform.position);
	}
}