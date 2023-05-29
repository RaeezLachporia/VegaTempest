using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermOVEMENT : MonoBehaviour
{
    private float horizontalMovement;
    public float speed = 10f;
    private bool isfacingRight;
    public bool canMove = true;
    [SerializeField] private Rigidbody2D Rigid;
    [SerializeField] private LayerMask groundLayer;
    public Button button;

    private void Start()
    {
        canMove = true;
        Rigid.constraints = RigidbodyConstraints2D.None;
    }
    private void Update()
    {
       
        flip();
        //canMovementBeDone();
        if (button.isActiveAndEnabled)
        {
            

                horizontalMovement = Input.GetAxisRaw("Horizontal");
                Rigid.velocity = new Vector2(horizontalMovement * 0, Rigid.velocity.y);

        }

    }

    

    private void flip()
    {
        
            
            Vector3 CharacterScale = transform.localScale;

        if (Input.GetAxisRaw("Horizontal")<0)
        {
            CharacterScale.x= -565;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            CharacterScale.x = 565;
        }

        transform.localScale = CharacterScale;

    }

    public void canMovementBeDone()
    {
        
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            Rigid.velocity = new Vector2(horizontalMovement * speed, Rigid.velocity.y);

        canMove = true;
       
       
    }

    public void movementCantBeDone()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Rigid.velocity = new Vector2(horizontalMovement * 0, Rigid.velocity.y);
        canMove = false;
        
    }

    public void freezeConstraints()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Rigid.velocity = new Vector2(horizontalMovement * 0, Rigid.velocity.y);


        Debug.Log("The prefab should be frozen ");
    }


}
