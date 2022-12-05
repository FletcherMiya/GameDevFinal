using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Detector : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Wall_lvl0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int i = 0; i <= enemies.Length - 1; i++)
        {
            if (enemies[i] == null)
            {
                count++;
                if (count == 3)
                {
                    GameObject.Destroy(Wall_lvl0);
                    player.GetComponent<PlayerController>().respawn = new Vector3(11.5f, -10.5f, 0);
                }
            }
        }
    }
}
