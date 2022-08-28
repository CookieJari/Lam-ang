using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public LayerMask groundLayer;
    public Movement mv;

    public BoxCollider2D bc;

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public bool wallSlide;
    public bool testWall;

    public float hangCounter;
    public float hangTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        onGround = isGrounded();
        onLeftWall = leftWall();
        onRightWall =rightWall();
        onWall = onLeftWall || onRightWall;
        CoyoteTime();
    }

    void CoyoteTime()
    {
        if (onGround)
        {
            hangCounter = hangTime;
            mv.secondJump = 1;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

    }

    bool isGrounded()
    {
        float extraHeight = 0.1f;
        Color rayColor;
        RaycastHit2D rayHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size - new Vector3(0.06f, 0f, 0f), 0f,Vector2.down,extraHeight,groundLayer);

        if (rayHit.collider != null) rayColor = Color.red;
        else rayColor = Color.green;

        // for drawing of ray
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.y*2), rayColor);

        return rayHit.collider != null;    
    }
    bool leftWall()
    {
        float extraHeight = 0.1f;
        Color rayColor;
        RaycastHit2D rayHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size - new Vector3(0.0f, 0.01f, 0f), 0f, Vector2.left, extraHeight, groundLayer);

        if (rayHit.collider != null) rayColor = Color.red;
        else rayColor = Color.green;

        // for drawing of ray
        Debug.DrawRay(bc.bounds.center + new Vector3(0, bc.bounds.extents.y), Vector2.left * (bc.bounds.extents.x + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(0, bc.bounds.extents.y), Vector2.left * (bc.bounds.extents.x + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x + extraHeight, bc.bounds.extents.y), Vector2.up* (bc.bounds.extents.y * 2), rayColor);

        return rayHit.collider != null;
    }
    bool rightWall()
    {
        float extraHeight = 0.1f;
        Color rayColor;
        RaycastHit2D rayHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size - new Vector3(0.0f, 0.01f, 0f), 0f, Vector2.right, extraHeight, groundLayer);

        if (rayHit.collider != null) rayColor = Color.red;
        else rayColor = Color.green;

        // for drawing of ray
        Debug.DrawRay(bc.bounds.center + new Vector3(0, bc.bounds.extents.y), Vector2.right * (bc.bounds.extents.x + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(0, bc.bounds.extents.y), Vector2.right * (bc.bounds.extents.x + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x + extraHeight, bc.bounds.extents.y), Vector2.down * (bc.bounds.extents.y * 2), rayColor);

        return rayHit.collider != null;
    }

}
