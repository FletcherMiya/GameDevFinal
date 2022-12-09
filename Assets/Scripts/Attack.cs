using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float lifetime;
    public float lag;

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(attackLag(lag));
        Vector3 temppos = GameObject.Find("Player").transform.position;
        transform.position = temppos;
        lifetime--;
        if(lifetime == 0)
        {
            Object.Destroy(gameObject);
        }
    }

    IEnumerator attackLag(float l)
    {
        yield return new WaitForSeconds(l);
        Debug.Log("attacked");
    }
}
