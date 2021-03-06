using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    #region walkVariables
    public float speed;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    #endregion

    #region jumpVariables

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    #endregion

    #region doubleJumpVariables

    private int extraJumps = 2;
    public float doubleJumpForce;

    #endregion 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

   
    void  FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);


        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (moveInput*speed, rb.velocity.y);
        if (facingRight == false && moveInput>0)
        {
            Flip();
        }
        else if(facingRight==true && moveInput<0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&extraJumps>0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if (isGrounded==true)
        {
            extraJumps = 1;
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
