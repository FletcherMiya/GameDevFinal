using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float lifetime;
    private GameObject player;
    public int waittime;
    public bool isReflected = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        rb.AddForce((player.transform.position - transform.position).normalized * speed);
        GetComponent<BoxCollider2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(waittime > 0)
        {
            waittime--;
        }
        if(waittime == 0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        lifetime--;
        if(lifetime == 0)
        {
            Object.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && isReflected)
        {
            Object.Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = player.GetComponent<PlayerController>().respawn;
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Object.Destroy(gameObject);
        }
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
