using System.Collections;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rdBody;
    public bool isWalking;
    public float walkTime, waitTime;
    private float walkCounter, waitCounter;
    private int WalkDirection;
    // Start is called before the first frame update
    void Start()
    {
        rdBody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            walkCounter -= Time.deltaTime;


            switch(WalkDirection)
            {
                case 0:
                    rdBody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 1:
                    rdBody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rdBody.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;
    }
}
