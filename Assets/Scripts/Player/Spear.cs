using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float damage;
    public float rotation;
    public Rigidbody2D rb;
    public bool hit = false;
    public LayerMask enemyLayer;

    private GameObject go;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        // ---------------- WARNING !!! DO NOT RE ARRANGE THE LAYERS ----------------- (if you do hits will not work)
        if (collision.gameObject.layer==10)
        {
            //get the HitScript of the enemy that was hit
            Health hs = collision.gameObject.GetComponent("Health") as Health;
            //call the damage function
            hs.TakeDamage(damage, transform.position.x);
            go = collision.gameObject;
            gameObject.transform.parent = go.transform;
        }
        
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {

        // This is to give the spear rotation while it moves about
        if (!hit)
        {
            rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }

        
    }
}
