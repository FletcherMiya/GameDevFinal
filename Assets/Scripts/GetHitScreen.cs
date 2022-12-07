using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitScreen : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempColor = GetComponent<SpriteRenderer>().color;
        if(tempColor.a > 0)
        {
            tempColor.a -= 0.01f;
        }

        GetComponent<SpriteRenderer>().color = tempColor;
    }

    public void hit()
    {
        var tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = .5f;

        GetComponent<SpriteRenderer>().color = tempColor;
    }
}
