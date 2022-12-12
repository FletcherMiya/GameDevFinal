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
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(v * speed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * speed, GetComponent<Rigidbody2D>().velocity.x);
        }

        float angle = angleBetweenTwoPoints(transform.position, player.transform.position);
        attackAnimation(angle);
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void attackAnimation(float ang)
    {

        if (ang >= -45 && ang < 45)
        {
            anim.SetTrigger("left");
        }

        if (ang >= -135 && ang < -45)
        {
            anim.SetTrigger("up");
        }


        if (ang >= 135 || ang < -135)
        {
            anim.SetTrigger("right");
        }

        if (ang >= 45 && ang < 135)
        {
            anim.SetTrigger("down");
        }
    }
}
