using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveMult;
    float horiMove;
    float vertiMove;

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
    }

    private void FixedUpdate()
    {
        AllMove(horiMove, vertiMove);

    }

    void AllMove(float toMoveX, float toMoveY)
    {
        float moveX = toMoveX * Time.fixedDeltaTime * moveMult;
        float moveY = toMoveY * Time.fixedDeltaTime * moveMult;
        myBody.velocity = new Vector3(moveX, moveY);

    }

}
