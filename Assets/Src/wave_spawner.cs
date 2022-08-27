using UnityEngine;
using UnityEngine.AI;

public class wave_spawner : MonoBehaviour
{
    public Transform[] spawns;

    void Start()
    {
        SpawnEnemyWave(5);
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
    }

    private void SpawnEnemyWave(int number)
    {
        if (number == 0)
        {
            return;
        }

        for (int i = 0; i < number; i++)
        {
            var selected_spawn_point = Random.Range(0, spawns.Length);
            // print(selected_spawn_point + "<selected point|länge array>" + spawns.Length + "size" + spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size);

            foreach (GameObject enemy in Gamemanager.Instance.enemies)
            {
                if (!enemy.activeSelf)
                {
                    
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
