using UnityEngine;
using UnityEngine.AI;

public class wave_spawner : MonoBehaviour
{
    public Transform[] spawns;
    private float _wave;
    void Start()
    {
        _wave = 1;
        //SpawnEnemyWave(5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            SpawnEnemyWave(10);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemyWave(1);
        }

        // if liste mit aktiven mobs leer
        // -> spawn mit wave x einen wert zum bestimmen wie viele mobs bei der wave spawnwn nur grade werte
        // -> ab bestimmter wave leben erhöhen dmg erhöhen 

        if (Gamemanager.Instance.active_enemies.Count == 0)
        {
            print("current wave: " + _wave + "spawning mobs: " + Mathf.Ceil(_wave * 5f));
            
            if(_wave == 2)
            {
                Gamemanager.Instance.gameData.EnemyStartHealth = 200;
                print("hat geklappt: " + Gamemanager.Instance.gameData.EnemyStartHealth);
            }

            SpawnEnemyWave(Mathf.Ceil(_wave*5f));
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
            // print(selected_spawn_point + "<selected point|länge array>" + spawns.Length + "size" + spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size);

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
