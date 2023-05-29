using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMovement : MonoBehaviour
{
    public float speed = 10f;
    private bool canMove = true;
    public Rigidbody2D RB;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            RB.velocity = new Vector2(horizontalInput * speed, RB.velocity.y);
        }
        flip();
    }

    public void StopMoving()
    {
        canMove = false;
    }

    private void flip()
    {


        Vector3 CharacterScale = transform.localScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            CharacterScale.x = -800;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            CharacterScale.x = 800;
        }

        transform.localScale = CharacterScale;

    }
}
