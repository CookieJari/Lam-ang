using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject go;
    public Animator animator;
    private float initialSpeed;
    private float blockSpeed;
    public float speed = 10;
    public float jumpForce = 5;
    public float slideSpeed = 5;
    public bool wallGrab;
    

    //dialoguesystem
    private NPC_DialogueTrigger npc;
    private Rigidbody2D body;



    private bool facingLeft = false;

    public bool validJump;
    public int secondJump = 1;

    private Collision coll;

    // Shield Declarations
    public bool shieldUp;
    public MeleeSpear ms;
    public ThrowSpear ts;
    public Health ht;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        go = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        ts = GetComponent<ThrowSpear>();

        initialSpeed = speed;
        blockSpeed = speed/2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        // This bit flips the character based on the direction
        if (!shieldUp)
        {
            if (x > 0 && facingLeft)
            {
                Flip();
            }
            if (x < 0 && !facingLeft)
            {
                Flip();
            }
        }
        

        
        // if player holds leftShift and presses any "Vertical" keys, the player will climb the wall
        // AKA WALL CLIMBING
        wallGrab = coll.onWall && Input.GetKey(KeyCode.LeftShift);
        if (wallGrab)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed);
        }
        // for the player jump
        validJump = ValidJump();
        if (Input.GetButtonDown("Jump") && validJump && !shieldUp)
        {
            Jump();
            //Set animation to jump
            animator.SetTrigger("Jump");
            
        }
        //for wall sliding
        if (coll.onWall && !coll.onGround && (rb.velocity.y<=0))
        {
            WallSlide();
        }

        // *******For Blocking*******
        Blocking();

        // ******************ANIMATIONS***********************************

        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("FacingLeft", facingLeft);
    }

    // ******************Dialogue System***********************************
    bool inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_DialogueTrigger>();

            if (Input.GetKey(KeyCode.E))
                npc.ActivateDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }

    void Blocking()
    {
        if (Input.GetMouseButton(1))
        {
            //for disabling the movement
            shieldUp = true;
            ms.shieldUp = true;
            ts.shieldUp = true;
            ht.shieldUp = true;

            //for slowing down the player
            speed = blockSpeed;
        }
        else
        {
            shieldUp = false;
            ms.shieldUp = false;
            ts.shieldUp = false;
            ht.shieldUp = false;

            speed = initialSpeed;
        }
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
