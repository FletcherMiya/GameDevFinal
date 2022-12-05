using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Detector : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject Wall_lvl2;
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
        for (int i = 0; i < enemies.Length - 1; i++)
        {
            if (enemies[i] == null)
            {
                count++;
                if (count == 23)
                {
                    GameObject.Destroy(Wall_lvl2);
                    player.GetComponent<PlayerController>().respawn = new Vector3(14.9f, -118.5f, 0);
                }
            }
        }
    }
}
