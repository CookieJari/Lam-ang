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
