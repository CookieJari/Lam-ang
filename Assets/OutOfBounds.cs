using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    protected void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag != "Player")
        {
            Destroy(enemy.gameObject);
        }

    }
}
