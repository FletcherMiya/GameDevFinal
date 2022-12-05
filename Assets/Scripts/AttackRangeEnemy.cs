using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = player.GetComponent<PlayerController>().respawn;
        }
    }
}
