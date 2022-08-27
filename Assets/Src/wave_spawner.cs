using UnityEngine;

public class wave_spawner : MonoBehaviour
{
    //private float _size = 10;
    public Transform[] spawns;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(5);
    }

    // Update is called once per frame
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
            // print(selected_spawn_point + "ponts" + spawns.Length + "size" + spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size) ;

            foreach (GameObject enemy in Gamemanager.Instance.enemies)
            {
                if (!enemy.activeSelf)
                {
                    enemy.SetActive(true);
                    enemy.transform.position = new Vector3(
                        Random.Range(spawns[selected_spawn_point].transform.position.x - (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2),
                        spawns[selected_spawn_point].transform.position.x + (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2)), 
                        0.1f, 
                        Random.Range(spawns[selected_spawn_point].transform.position.z - (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2), 
                        spawns[selected_spawn_point].transform.position.z + (spawns[selected_spawn_point].GetComponent<spawner_visualization>()._size / 2)));
                    enemy.GetComponent<enemy_logic>().SetAgentDestination();
                    break;
                }
            }
        }
        //int counter = 0;

        //foreach (GameObject enemy in Gamemanager.Instance.enemies)
        //{
        //    if (!enemy.activeSelf)
        //    {
        //        enemy.SetActive(true);
        //        enemy.transform.position = new Vector3(Random.Range(transform.position.x - (_size / 2), transform.position.x + (_size / 2)), 0.1f, Random.Range(transform.position.z - (_size / 2), transform.position.z + (_size / 2)));
        //        enemy.GetComponent<enemy_logic>().SetAgentDestination();
        //        counter++;
        //    }
        //    if (counter == number)
        //    {
        //        return;
        //    }
        //}

    }

    ////Draws Cube thats only visible when selected <- big nice
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.4F);
    //    Gizmos.DrawCube(transform.position, new Vector3(_size, 0.1f, _size));
    //}
}
