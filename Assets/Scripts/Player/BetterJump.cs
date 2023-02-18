/*
 * Title: Biag ni Lam-ang -  A platformer game about the Ilokano Folklore of Biag ni Lam-ang
 * 
 * Programmers: Zalman Hajari Parial
 * 
 * Sub-System: Physics system, Player Movement system
 * 
 * Date written: August 28, 2022    Date Revised: December 23, 2023
 * 
 * Purpose: Controls the jumping of the player
 * 
 * Data Structures, algorithms, and control:
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (rb.velocity.y<0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1) *Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

}
