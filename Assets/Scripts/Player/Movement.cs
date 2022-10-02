using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject go;
    public Animator animator;
    public float speed = 10;
    public float jumpForce = 5;
    public float slideSpeed = 5;
    public bool wallGrab;



    private bool facingLeft = false;

    public bool validJump;
    public int secondJump = 1;

    private Collision coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        go = GetComponent<GameObject>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        // This bit flips the character based on the direction
        if (x>0 && facingLeft)
        {
            Flip();
        }
        if (x < 0 && !facingLeft)
        {
            Flip();
        }

        
        // if player holds leftShift and presses any "Vertical" keys, the player will climb the wall
        wallGrab = coll.onWall && Input.GetKey(KeyCode.LeftShift);
        if (wallGrab)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed);
        }
        // for the player jump
        validJump = ValidJump();
        if (Input.GetButtonDown("Jump") && validJump)
        {
            Jump();
            
        }
        //for wall sliding
        if (coll.onWall && !coll.onGround && (rb.velocity.y<=0))
        {
            WallSlide();
        }

        // ******************ANIMATIONS***********************************

        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetBool("FacingLeft", facingLeft);
    }

    void Flip()
    {
        transform.Rotate(0f,180f,0f);

        facingLeft = !facingLeft;
    }
    
    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));

    }

    private void Jump()
    {
        // does the jump
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
        // subtracts 1 from double jump
        if (!coll.onGround && coll.hangCounter <= 0)
        {
            secondJump--;
        }
    }

    bool ValidJump()
    {
        // if coyote time and you still have remaining jumps
        if (coll.hangCounter > 0 || secondJump > 0)
        {
            return true;
        }
        return false;
    }

    void WallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
    }
}