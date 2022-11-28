using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float lifetime;

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
