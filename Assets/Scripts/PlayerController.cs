using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashDist;
    public int dashCD;
    public GameObject attack;
    public Transform mouseAim;
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
            dashCD = 50;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 36f);
        mouseAim.transform.position = mouseWorldPosition;
        float angle = angleBetweenTwoPoints(transform.position, mouseWorldPosition);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(attack, transform.position, Quaternion.Euler(0, 0, angle));
        }

        
    }

    private void FixedUpdate()
    {
        if(dashCD > 0)
        {
            dashCD--;
        }
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
