using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonsForPlayerOne : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;

    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * moveSpeed;
        Debug.Log("Button is clicked");
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * moveSpeed;
    }

    public void stopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
