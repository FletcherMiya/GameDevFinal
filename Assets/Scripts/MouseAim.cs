using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseAim : MonoBehaviour
{
    public Transform mouseAim;
    public Transform player;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * -10f);
        mouseAim.transform.position = mouseWorldPosition;
        Debug.Log(mouseAim.transform.position);
        float angle = angleBetweenTwoPoints(mouseAim.transform.position, mouseWorldPosition);
        
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.x - a.x, b.y - a.y) * Mathf.Rad2Deg;
    }
}
