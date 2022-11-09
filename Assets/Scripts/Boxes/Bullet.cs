using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Destroy the bullet when we are colliding to something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        // Enemies take damage

    if (collision.gameObject.TryGetComponent<BoxHealth>(out BoxHealth enemyComponent))
    {
        enemyComponent.takeDamage(1);
    }

       Destroy(gameObject); //destroy bullet in all cases;
    }

}
