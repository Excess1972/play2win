using UnityEngine;

/**
 * this functions will be called by clicking on the buildbuttons in the hud
 */
public class TowerBluePrintFactory : MonoBehaviour
{
    public GameObject tower_01_bp;
    public GameObject tower_02_bp;

    public void spawn_tower_01_bp()
    {
        Instantiate(tower_01_bp);
    }
    
    public void spawn_tower_02_bp()
    {
        Instantiate(tower_02_bp);
    }
}