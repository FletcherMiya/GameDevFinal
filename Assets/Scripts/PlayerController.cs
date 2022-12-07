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
    public Camera cam;
    public Animator anim;
    public Vector3 respawn;
    public int hitcount;
    // Start is called before the first frame update
    void Start()
    {
        respawn = new Vector3(17.5f, 82f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h * speed, v * speed, 0);
        
        //Dash
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0)
        {
            transform.position += new Vector3(h * speed * dashDist, v * speed * dashDist, 0);
            dashCD = dashCDAmnt;
        }

        //Attack
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * -10f);
        mouseAim.transform.position = mouseWorldPosition;
        float angle = angleBetweenTwoPoints(transform.position, mouseWorldPosition);
        Debug.Log("The angle is" + angle);
        if (Input.GetMouseButtonDown(0) && attackCD == 0)
        {
            Instantiate(attack, transform.position, Quaternion.Euler(0, 0, angle));
            attackCD = attackCDAmnt;
            attackAnimation(angle);
        }

        MoveAnimation();

        if(hitcount == 0)
        {
            transform.position = respawn;
            hitcount = 3;
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

    private void MoveAnimation()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
        }

    }

    private void attackAnimation(float ang)
    {

        if (ang >= -45 && ang < 45)
        {
            anim.SetTrigger("attackLeft");
        }

        if (ang >= -135 && ang < -45)
        {
            anim.SetTrigger("attackUp");
        }


        if (ang >= 135 || ang < -135)
        {
            anim.SetTrigger("attackRight");
        }

        if (ang >= 45 && ang < 135)
        {
            anim.SetTrigger("attackDown");
        }
    }
}
