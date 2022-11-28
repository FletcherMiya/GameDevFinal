using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashDist;
    public int dashCD;
    public int dashCDAmnt;
    public GameObject attack;
    public Transform mouseAim;
    public int attackCD;
    public int attackCDAmnt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h * speed, v * speed, 0);
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0)
        {
            transform.position += new Vector3(h * speed * dashDist, v * speed * dashDist, 0);
            dashCD = dashCDAmnt;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * -10f);
        mouseAim.transform.position = mouseWorldPosition;
        float angle = angleBetweenTwoPoints(transform.position, mouseWorldPosition);

        if (Input.GetMouseButtonDown(0) && attackCD == 0)
        {
            Instantiate(attack, transform.position, Quaternion.Euler(0, 0, angle));
            attackCD = attackCDAmnt;
        }

        
    }

    private void FixedUpdate()
    {
        if(dashCD > 0)
        {
            dashCD--;
        }
        if(attackCD > 0)
        {
            attackCD--;
        }
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
