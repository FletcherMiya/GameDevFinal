using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform mouseAim;
    public Transform player;
    public Transform facing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 36f);
        mouseAim.transform.position = mouseWorldPosition;
        facing.position = player.transform.position;
        float angle = angleBetweenTwoPoints(mouseAim.transform.position, mouseWorldPosition);
        facing.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private float angleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.x - a.x, b.y - a.y) * Mathf.Rad2Deg;
    }
}