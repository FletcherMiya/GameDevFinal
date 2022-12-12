using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public int shootCD;
    public int shootCDAmnt;
    public float aimDistancce;
    public GameObject bullet;
    public GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float angle = angleBetweenTwoPoints(transform.position, player.transform.position);
        attackAnimation(angle);
    }
    void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (shootCD > 0)
        {
            shootCD--;
        }
        if(shootCD == 0 && (playerDistance < aimDistancce))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            shootCD = shootCDAmnt;
        }
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
