using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] spawns;
    private float _wave;
    public TextMeshProUGUI currentWaveText;

    void Start()
    {
        _wave = 1;
        //SpawnEnemyWave(5);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q)) 
        //{
        //    SpawnEnemyWave(10);
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    SpawnEnemyWave(1);
        //}

        // if liste mit aktiven mobs leer
        // -> spawn mit wave x einen wert zum bestimmen wie viele mobs bei der wave spawnwn nur grade werte
        // -> ab bestimmter wave leben erh�hen dmg erh�hen 

        if (Gamemanager.Instance.active_enemies.Count == 0)
        {
            // print("current wave: " + _wave + "spawning mobs: " + Mathf.Ceil(5f + Mathf.Pow(1.19f, _wave)));
            
            if(_wave == 5)
            {
                Gamemanager.Instance.gameData.EnemyStartHealth = 200;
                Gamemanager.Instance.gameData.EnemyDmg = 12;
                // print("wave 5, hat geklappt, leben ist jetzt: " + Gamemanager.Instance.gameData.EnemyStartHealth);
            }
            if (_wave == 10)
            {
                Gamemanager.Instance.gameData.EnemyStartHealth = 250;
                Gamemanager.Instance.gameData.EnemyDmg = 15;
                // print("wave 10, hat geklappt, leben ist jetzt: " + Gamemanager.Instance.gameData.EnemyStartHealth);
            }
            if (_wave == 15)
            {
                Gamemanager.Instance.gameData.EnemyStartHealth = 300;
                Gamemanager.Instance.gameData.EnemyDmg = 19;
                // print("wave 15, hat geklappt, leben ist jetzt: " + Gamemanager.Instance.gameData.EnemyStartHealth);
            }
            if (_wave == 20)
            {
                Gamemanager.Instance.gameData.EnemyStartHealth = 400;
                Gamemanager.Instance.gameData.GoldEarned = 8;
                Gamemanager.Instance.gameData.EnemyDmg = 25;
                // print("wave 20, hat geklappt, leben ist jetzt: " + Gamemanager.Instance.gameData.EnemyStartHealth);
            }

            SpawnEnemyWave(Mathf.Ceil(5f + Mathf.Pow(1.19f, _wave)));
            currentWaveText.text = "Current Wave: " + _wave.ToString();
            _wave++;
        }
    }

    private void SpawnEnemyWave(float mobs_to_spawn)
    {
        if (mobs_to_spawn == 0)
        {
            return;
        }

        for (int i = 0; i < mobs_to_spawn; i++)
        {
            var selected_spawn_point = Random.Range(0, spawns.Length);
            // print(selected_spawn_point + "<selected point|l�nge array>" + spawns.Length + "size" + spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size);

            foreach (GameObject enemy in Gamemanager.Instance.enemies)
            {
                if (!enemy.activeSelf)
                {  
                    Gamemanager.Instance.active_enemies.Add(enemy);
                    enemy.SetActive(true);
                    enemy.GetComponent<NavMeshAgent>().Warp(new Vector3(
                        Random.Range(spawns[selected_spawn_point].transform.position.x - (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2),
                        spawns[selected_spawn_point].transform.position.x + (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2)),
                        0.1f,
                        Random.Range(spawns[selected_spawn_point].transform.position.z - (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2),
                        spawns[selected_spawn_point].transform.position.z + (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2))));
                    enemy.GetComponent<enemy_logic>().SetAgentDestination();
                    break;
                }
            }
        }
    }
}
