using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        lifetime--;
        if(lifetime == 0)
        {
            Object.Destroy(gameObject);
        }
    }
}
