using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    public Transform bullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            Vector3 oldvelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -oldvelocity;
            collision.gameObject.GetComponent<Projectile>().isReflected = true;
        }
    }
}
