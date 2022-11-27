using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public float speed;
    float h;
    float v;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        if (cam.transform.position != tempPos)
        {
            if (cam.transform.position.x < tempPos.x)
            {
                h = 1;
            }
            if (cam.transform.position.x > tempPos.x)
            {
                h = -1;
            }
            if (cam.transform.position.y > tempPos.y)
            {
                v = -1;
            }
            if (cam.transform.position.y < tempPos.y)
            {
                v = 1;
            }
        }
        cam.transform.position += new Vector3(h * speed, v * speed, 0);

    }
}
