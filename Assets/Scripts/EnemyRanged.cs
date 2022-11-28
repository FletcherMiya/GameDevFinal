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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 playerposition = player.transform.position;
        float angle = angleBetweenTwoPoints(transform.position, playerposition);
        if (shootCD > 0)
        {
            shootCD--;
        }
        if(shootCD == 0 && (playerDistance < aimDistancce))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle+90));
            shootCD = shootCDAmnt;
        }
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}