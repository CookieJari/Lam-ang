using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticleEffect : MonoBehaviour
{

    public GameObject diePEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            // Die
            Die();
        }
    }

    void Die() 
    {
        if (diePEffect != null){
            Instantiate ( diePEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); 


    }
}
