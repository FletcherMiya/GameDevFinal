using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelle : MonoBehaviour
{
    public GameObject player;
    public float speed;
    float h;
    float v;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        if (transform.position != tempPos)
        {
            if (transform.position.x < tempPos.x)
            {
                h = 1;
            }
            if (transform.position.x > tempPos.x)
            {
                h = -1;
            }
            if (transform.position.y > tempPos.y)
            {
                v = -1;
            }
            if (transform.position.y < tempPos.y)
            {
                v = 1;
            }
        }
        float playerdistance = Vector3.Distance(player.transform.position, transform.position);
        if(playerdistance < range)
        {
            transform.position += new Vector3(h * speed, v * speed, 0);
        }
    }
}
