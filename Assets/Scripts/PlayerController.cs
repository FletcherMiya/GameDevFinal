using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashDist;
    public int dashCD;
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
        /*if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0 && h < 0)
        {
            transform.position -= new Vector3(dashDist, 0 ,0);
            dashCD = 50;
        }
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0 && h > 0)
        {
            transform.position += new Vector3(dashDist, 0, 0);
            dashCD = 50;
        }
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0 && v < 0)
        {
            transform.position -= new Vector3(0, dashDist, 0);
            dashCD = 50;
        }
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0 && v > 0)
        {
            transform.position += new Vector3(0, dashDist, 0);
            dashCD = 50;
        }*/
        if (Input.GetKey(KeyCode.LeftShift) && dashCD == 0)
        {
            transform.position += new Vector3(h * speed * dashDist, v * speed * dashDist, 0);
            dashCD = 50;
        }
    }

    private void FixedUpdate()
    {
        if(dashCD > 0)
        {
            dashCD--;
        }
    }
}
