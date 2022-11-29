using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(13.5f, -8.5f, 0);
        }
    }
}
