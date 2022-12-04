
using System.Collections.Generic;
using UnityEngine;


public class DemoView : MonoBehaviour
{
   
    public GameObject[] AllPrefabs;

    private List<GameObject> Curent=new List<GameObject>();
    private int index = 0;//
    private int rot;//To rotate each prefab during spawn
    //Prefabs respawn function
    public void Spawn()
    {
        //We clean everything first
        for (int i = 0; i < Curent.Count; i++)
        {
            Destroy(Curent[i]);
        }
        Curent.Clear();

        //Spawn a new group of prefabs
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if (index < AllPrefabs.Length)
                {
                    GameObject clone = Instantiate(AllPrefabs[index]);
                    clone.transform.position = new Vector3(x * 4, 1, y * 4);
                    Curent.Add(clone);
                    clone.transform.rotation = Quaternion.Euler(0,rot,0);
                    rot += 90;
                }
                else
                {
                    index = 0;
                }
                index++;
            }
        }
    }
   
    //Next ship button
    public void Next()
    { 
        rot += 90; 
        Spawn();
    }
   
   
    void Start()
    { 
        Spawn();
    }

}
