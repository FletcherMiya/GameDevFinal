using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveMult;
    float horiMove;
    float vertiMove;
    public float rushMultPublic;
    float rushMult;

    Rigidbody2D myBody;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horiMove = Input.GetAxis("Horizontal");
        vertiMove = Input.GetAxis("Vertical");
        rush();
    }

    private void FixedUpdate()
    {
        AllMove(horiMove, vertiMove);


    }

    void AllMove(float toMoveX, float toMoveY)
    {
        float moveX = toMoveX * Time.fixedDeltaTime * moveMult * rushMult;
        float moveY = toMoveY * Time.fixedDeltaTime * moveMult * rushMult;
        myBody.velocity = new Vector3(moveX, moveY);

    }

    void rush()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rushMult = rushMultPublic;
            Debug.Log("sure");
        }
        else
        {
            rushMult = 1;
        }

    }

}
