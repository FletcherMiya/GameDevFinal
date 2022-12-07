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
            FindObjectOfType<HitStop>().stop(0.1f);
            Destroy(collision.gameObject);
            Screenshake.Instance.ShakeCamera(5f, .1f);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            FindObjectOfType<HitStop>().stop(0.1f);
            Vector3 oldvelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = -oldvelocity;
            collision.gameObject.GetComponent<Projectile>().isReflected = true;
            Screenshake.Instance.ShakeCamera(3f, .1f);
        }
    }
}
