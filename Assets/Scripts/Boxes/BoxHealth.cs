/*
 * Title: Biag ni Lam-ang -  A platformer game about the Ilokano Folklore of Biag ni Lam-ang
 * 
 * Programmers:  Asher Manangan
 * 
 * Sub-System: Animation System, Combat System, Health System
 * 
 * Date written: Decenber 15, 2022    Date Revised: January 2, 2023
 * 
 * Purpose: Box destruction is handled by this script
 * 
 * Data Structures, algorithms, and control: Arrays,
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    
    private void Start()
    {
        health = maxHealth;

    }

    public void takeDamage(float damageAmount)
    {
        health -= damageAmount; // 3-> 2 -> 1 -> 0 = Enemy has died

        if (health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
