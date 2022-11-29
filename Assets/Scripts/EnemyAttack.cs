using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject attack;
    public int attackCD;
    public int attackCDAmnt;
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
            if ((Mathf.Abs(transform.position.x - tempPos.x) <= 2) && (Mathf.Abs(transform.position.y - tempPos.y) <= 2))
            {
                float angle = angleBetweenTwoPoints(transform.position, tempPos);
                if (attackCD == 0)
                {
                    Instantiate(attack, transform.position, Quaternion.Euler(0, 0, angle));
                    attackCD = attackCDAmnt;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (attackCD > 0)
        {
            attackCD--;
        }
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
