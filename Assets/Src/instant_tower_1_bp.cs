using UnityEngine;

public class instant_tower_1_bp : MonoBehaviour
{
    public GameObject tower_01_bp;

    public void spawn_tower_01_bp()
    {
        Instantiate(tower_01_bp);
    }
}